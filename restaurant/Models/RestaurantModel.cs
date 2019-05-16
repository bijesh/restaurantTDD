using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restaurant.Models
{
    public class RestaurantModel
    {
        public string RestaurantName { get; set; }
        public string Rating { get; set; }
        public IEnumerable<string> CuisineList { get; set; }
    }
}