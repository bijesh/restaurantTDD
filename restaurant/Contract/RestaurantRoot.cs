using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace restaurant.Contract
{
    [ExcludeFromCodeCoverage]
    public class RestaurantRoot
    {
        [JsonProperty("Restaurants")]
        public List<Restaurant> Restaurants;
    }
}