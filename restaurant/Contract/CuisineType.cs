using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;

namespace restaurant.Contract
{
    [ExcludeFromCodeCoverage]
    public class CuisineType
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("SeoName")]
        public string SeoName { get; set; }
    }
}