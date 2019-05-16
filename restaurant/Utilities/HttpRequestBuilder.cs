using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using restaurant.Interface;

namespace restaurant.Utilities
{
    public class HttpRequestBuilder : IHttpRequestBuilder
    {
        public const string ContentTypeValue = "application/json";

        public HttpRequestMessage GetHttpRequestMessage(Uri uri, IDictionary<string, string> apiRequestHeaders,
            HttpMethod httpMethod)
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                RequestUri = uri,
                Method = httpMethod
            };
            httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentTypeValue));
            if (apiRequestHeaders != null)
            {
                foreach (var item in apiRequestHeaders)
                {
                    httpRequestMessage.Headers.Add(item.Key, item.Value);
                }
            }
            return httpRequestMessage;
        }
    }
}