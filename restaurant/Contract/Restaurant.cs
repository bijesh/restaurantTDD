using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using restaurant.Contract;

namespace restaurant.Contract
{
    [ExcludeFromCodeCoverage]
    public class Restaurant
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("CuisineTypes")]
        public List<CuisineType> CuisineTypes { get; set; }
        [JsonProperty("RatingStars")]
        public double RatingStars { get; set; }
    }
}