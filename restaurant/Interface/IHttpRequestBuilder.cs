using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace restaurant.Interface
{
    public interface IHttpRequestBuilder
    {
        HttpRequestMessage GetHttpRequestMessage(Uri uri, IDictionary<string, string> apiRequestHeaders, HttpMethod httpMethod);
    }
}
