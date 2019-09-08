using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Utilities;

namespace Components
{

    public static class RequestHelper
    {
        // Login request headers
        public static HttpClient AddDefaultRequestHeaders(this HttpClient client)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.DefaultRequestHeaders.UrlEncoded));
            client.DefaultRequestHeaders.Add(Constants.DefaultRequestHeaders.ClientNameKey, Constants.DefaultRequestHeaders.ClientNameValue);
            client.DefaultRequestHeaders.Add(Constants.DefaultRequestHeaders.ApiKey, Constants.DefaultRequestHeaders.ApiValue);
            return client;
        }

        public static WebHeaderCollection AddDefaultRequestHeaders_WebHeaderCollection(this WebHeaderCollection webHeaderCollection)
        {
            webHeaderCollection.Add(Constants.DefaultRequestHeaders.ClientNameKey, Constants.DefaultRequestHeaders.ClientNameValue);
            webHeaderCollection.Add(Constants.DefaultRequestHeaders.ApiKey, Constants.DefaultRequestHeaders.ApiValue);
            webHeaderCollection.Add(Constants.DefaultRequestHeaders.AuthorizationKey, (!String.IsNullOrEmpty((string)HttpContext.Current.Session["AccessToken"]) ? "Bearer " + HttpContext.Current.Session["AccessToken"].ToString() : ""));
            return webHeaderCollection;
        }

        public static void GetPostRequestHeaders(this HttpClient client)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(RequestHelper.GetJsonMediaType());
            client.DefaultRequestHeaders.Add(Constants.DefaultRequestHeaders.ClientNameKey, Constants.DefaultRequestHeaders.ClientNameValue);
            client.DefaultRequestHeaders.Add(Constants.DefaultRequestHeaders.ApiKey, Constants.DefaultRequestHeaders.ApiValue);
            client.DefaultRequestHeaders.Add(Constants.DefaultRequestHeaders.AuthorizationKey, (!String.IsNullOrEmpty((string)HttpContext.Current.Session["AccessToken"])) ? "Bearer " + HttpContext.Current.Session["AccessToken"].ToString() : "");
        }

        public static void GetPostRequestHeadersAnonymous(this HttpClient client)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(RequestHelper.GetJsonMediaType());
            client.DefaultRequestHeaders.Add(Constants.DefaultRequestHeaders.ClientNameKey, Constants.DefaultRequestHeaders.ClientNameValue);
            client.DefaultRequestHeaders.Add(Constants.DefaultRequestHeaders.ApiKey, Constants.DefaultRequestHeaders.ApiValue);
        }

        public static MediaTypeWithQualityHeaderValue GetJsonMediaType()
        {
            return new MediaTypeWithQualityHeaderValue("application/json");
        }
    }

}

