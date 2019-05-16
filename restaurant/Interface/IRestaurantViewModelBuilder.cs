using restaurant.Contract;
using restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant.Interface
{
    public interface IRestaurantViewModelBuilder
    {
        RestaurantViewModel Build(IEnumerable<Restaurant> restaurantList);
    }
}
