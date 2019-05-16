using restaurant.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant.Interface
{
    public interface IRestaurantService
    {
        Task<IEnumerable<Restaurant>> SearchRestaurants(string postCode);
    }
}
