using restaurant.Contract;
using restaurant.Interface;
using restaurant.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurant.ViewModelFactory
{
    public class RestaurantViewModelBuilder : IRestaurantViewModelBuilder
    {       
        public RestaurantViewModel Build(IEnumerable<Restaurant> restaurantList)
        {
            var restaurantModelBag = new ConcurrentBag<RestaurantModel>();
            Parallel.ForEach(restaurantList, restaurant =>
            {
                restaurantModelBag.Add(GetRestaurantViewModel(restaurant));
            });

            return new RestaurantViewModel
            {
                RestaurantList = restaurantModelBag
            };
           
        }
        private RestaurantModel GetRestaurantViewModel(Restaurant restaurant)
        {
            return new RestaurantModel
            {
                RestaurantName = restaurant.Name,
                Rating = restaurant.RatingStars.ToString(),
                CuisineList = restaurant.CuisineTypes.Select(i => i.Name).ToList()
            };
        }
    }
}