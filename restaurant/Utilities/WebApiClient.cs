using restaurant.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace restaurant.Utilities
{
    public class WebApiClient : IWebApiClient
    {
        private HttpClient _client;
        private IHttpRequestBuilder _httpRequestBuilder;

        public WebApiClient(IHttpRequestBuilder httpRequestBuilder)
        {
            _client = new HttpClient();
            _httpRequestBuilder = httpRequestBuilder;
        }

        public async Task<HttpResponseMessage> GetAsync(Uri uri, IDictionary<string, string> apiRequestHeaders)
        {
            var request = _httpRequestBuilder.GetHttpRequestMessage(uri, apiRequestHeaders, HttpMethod.Get);
            var response = await _client.SendAsync(request);
            return response;
            
        }
    }
}