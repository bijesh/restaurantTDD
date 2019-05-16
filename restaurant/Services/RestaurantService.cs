using restaurant.Contract;
using restaurant.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using restaurant.Utilities;

namespace restaurant.Services
{
    public class RestaurantService : IRestaurantService
    {
        private IWebApiClient _webApiClient;
        
        public RestaurantService(IWebApiClient webApiClient)
        {
            _webApiClient = webApiClient;
        }

        public async Task<IEnumerable<Restaurant>> SearchRestaurants(string postCode)
        {
             //TODO Catch and Log Exception 
             //TODO Monitor and Log Performance 
             //TODO: Read the URL and Headers values from web config
             Uri uri = new Uri($"https://public.je-apis.com/restaurants?q={ postCode }");
             //TODO: check the url is valid
            
                var response = await _webApiClient.GetAsync(uri, GetHeader());
                if (response.StatusCode == HttpStatusCode.OK)
                {
                   var result =  await response.Content.ReadAsAsync<RestaurantRoot>();
                   return result.Restaurants;
                }
                return null;
        }

        private Dictionary<string, string> GetHeader()
        {
            return new Dictionary<string, string>
            {
                [DefaultApiHeaderConstants.Authorization] = "Basic VGVjaFRlc3Q6bkQ2NGxXVnZreDVw",
                [DefaultApiHeaderConstants.Tenant] = "uk",
                [DefaultApiHeaderConstants.Language] = "en-GB",
                [DefaultApiHeaderConstants.Host] = "public.je-apis.com"
                
            };
        }
    }
}