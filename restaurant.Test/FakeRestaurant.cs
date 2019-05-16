using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using restaurant.Contract;

namespace restaurant.Test
{
    [ExcludeFromCodeCoverage]
    public class FakeRestaurant
    {
        internal static IEnumerable<Restaurant> GetResturantList()
        {
            return new List<Restaurant>()
            {
                new Restaurant() {Name = "Resturant1", RatingStars = 5.5,CuisineTypes = GetCuisineType()},
                new Restaurant() {Name = "Resturant2", RatingStars = 4.5,CuisineTypes = GetCuisineType()}
            };
        }

        private static List<CuisineType> GetCuisineType()
        {
            return new List<CuisineType>()
            {
                new CuisineType{ Id=87,Name = "Pizza", SeoName ="Pizza"},
                new CuisineType{Id=85,Name = "Chicken",SeoName = "Chicken"}
            };
        }
    }
}
