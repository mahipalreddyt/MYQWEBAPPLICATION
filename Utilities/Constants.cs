using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Constants
    {
        public static class HttpMethod
        {
            public const string Post = "Post";
            public const string Put = "Put";
            public const string Get = "Get";
            public const string Delete = "Delete";
        }


        public static class SocialMediaType
        {
            public const string Twitter = "Twitter";
            public const string Facebook = "Facebook";
            public const string LinkedIn = "LinkedIn";
        }


        public static class ContentType
        {
            public const string Json = "application/json";
        }

        public static class Accept
        {
            public const string xwwwformurlencoded = "application/x-www-form-urlencoded";
        }


        public class DefaultRequestHeaders
        {
            public const string UrlEncoded = "application/x-www-form-urlencoded";
            public const string ClientNameKey = "X-Client-Name";
            public const string ClientNameValue = "JobBoard-WebApp";
            public const string ApiKey = "X-Api-Key";
            public const string ApiValue = "saV/bDgtYyDVpAdKDNB8V6nKQxAP65IG+Do7hNsqaI+dSqpjpZlK8Zhf188GHGGfaA30IhzJax1RCkF0ZmgGhQ==";
            public const string AuthorizationKey = "Authorization";
        }

    }
}
