using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace restaurant.Interface
{
    public interface IWebApiClient
    {
        Task<HttpResponseMessage> GetAsync(Uri uri, IDictionary<string, string> apiRequestHeaders);
    }
}
