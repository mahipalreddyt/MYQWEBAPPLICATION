using Components;
using Components.ResponseObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace DAL
{
    public class EcommerceProxy
    {
        //Get method
        public ApiResponse<C> GetApi<T, C>(T requestdata, string uri)
        {
            var myContent = new List<string>();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(requestdata))
            {
                if (property.GetValue(requestdata) != null && !string.IsNullOrEmpty(property.GetValue(requestdata).ToString()))
                {
                    myContent.Add(property.Name + "=" + property.GetValue(requestdata));
                }
            }
            uri += "?" + string.Join("&", myContent);

            ApiResponse<C> apiResponse = new ApiResponse<C>();

            return GetApi<C>(uri);
        }

        public ApiResponse<T> GetApi<T>(string UrlParameters)
        {
            ApiResponse<T> apiResponse = new ApiResponse<T>();

            if (!string.IsNullOrEmpty(UrlParameters))
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(UrlParameters);
                WebHeaderCollection myWebHeaderCollection = request.Headers;
                myWebHeaderCollection.AddDefaultRequestHeaders_WebHeaderCollection();
                request.Method = Constants.HttpMethod.Get;
                request.ContentType = Constants.ContentType.Json;
                request.Accept = Constants.Accept.xwwwformurlencoded;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            var result = reader.ReadToEnd();

                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                apiResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(result);
                            }
                        }
                    }
                }
            }

            return apiResponse;
        }


        //Post method
        public async Task<ApiResponse<C>> PostAsyncApi<T, C>(T requestData, string uri)
        {

            ApiResponse<C> apiResponse = null;
            try
            {
                if (!string.IsNullOrEmpty(uri))
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                   // RequestHelper.GetPostRequestHeaders(client);
                    var response = await client.PostAsync(uri, GetByteContent(requestData));
                    apiResponse = SetResponseAsync<C>(response);
                }

                return apiResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ApiResponse<C>> PostAsyncApiAnonymous<T, C>(T requestData, string uri)
        {

            ApiResponse<C> apiResponse = null;
            try
            {
                if (!string.IsNullOrEmpty(uri))
                {
                    HttpClient client = new HttpClient();
                    RequestHelper.GetPostRequestHeadersAnonymous(client);
                    var response = await client.PostAsync(uri, GetByteContent(requestData));
                    apiResponse = SetResponseAsync<C>(response);
                }

                return apiResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public ApiResponse<C> PostApi<T, C>(T data, string uri, string method = Constants.HttpMethod.Get, string contentType = Constants.ContentType.Json,
           string Accept = Constants.Accept.xwwwformurlencoded)
        {
            var myContent = JsonConvert.SerializeObject(data);
            
            byte[] dataBytes = Encoding.UTF8.GetBytes(myContent);
            ApiResponse<C> apiResponse = new ApiResponse<C>();

            if (!string.IsNullOrEmpty(uri))
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                WebHeaderCollection myWebHeaderCollection = request.Headers;
                myWebHeaderCollection.AddDefaultRequestHeaders_WebHeaderCollection();
                request.Method = method;
                request.ContentType = contentType;
                request.Accept = Accept;


                using (Stream requestBody = request.GetRequestStream())
                {
                    requestBody.Write(dataBytes, 0, dataBytes.Length);
                }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            var result = reader.ReadToEnd();

                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                apiResponse = JsonConvert.DeserializeObject<ApiResponse<C>>(result);
                            }
                        }
                    }
                }
            }

            return apiResponse;
        }

        #region Private Methods
        private static ByteArrayContent GetByteContent<T>(T AddRegistrationDetails)
        {
            var myContent = JsonConvert.SerializeObject(AddRegistrationDetails);
            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = RequestHelper.GetJsonMediaType();
            return byteContent;
        }

        private static ApiResponse<T> SetResponseAsync<T>(HttpResponseMessage httpResponseMessage)
        {
            ApiResponse<T> apiResponse = null;

            Console.WriteLine("Request Message Information:- \n\n" + httpResponseMessage.RequestMessage + "\n");
            Console.WriteLine("Response Message Header \n\n" + httpResponseMessage.Content.Headers + "\n");
            // Get the response
            var customerJsonString = httpResponseMessage.Content.ReadAsStringAsync();
            Console.WriteLine("Your response data is: " + customerJsonString);

            // Deserialise the data (include the Newtonsoft JSON Nuget package if you don't already have it)
            apiResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(customerJsonString?.Result);
            // Do something with it
            return apiResponse;
        }
        #endregion



        static readonly HttpClient Client = new HttpClient();
        public async Task<C> PostAsyncMahi<T,C>(string url, T data) where C : class, new()
        {
            try
            {
                string content = JsonConvert.SerializeObject(data);
                var buffer = Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await Client.PostAsync(url, byteContent).ConfigureAwait(false);
                string result = await response.Content.ReadAsStringAsync();
                if (response.StatusCode != HttpStatusCode.OK)
                {

                    
                    return  new C();
                }
                
                return JsonConvert.DeserializeObject<C>(result);
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    string responseContent = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                    throw new System.Exception($"response :{responseContent}", ex);
                }
                throw;
            }
        }
    }
}
