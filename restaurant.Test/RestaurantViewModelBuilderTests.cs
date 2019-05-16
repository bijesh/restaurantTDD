using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using restaurant.Contract;
using restaurant.Models;
using restaurant.ViewModelFactory;
using NUnit.Framework;

namespace restaurant.Test
{
    [TestFixture]
    [Parallelizable]
    [ExcludeFromCodeCoverage]
    public class RestaurantViewModelBuilderTests
    {

        [Test]
        public void RestaurantViewModelBuilderBuildReturnExpectedInstance()
        {
            var restaurantViewModelBuilder = new RestaurantViewModelBuilder();
            var actualResult = restaurantViewModelBuilder.Build(new List<Restaurant>());
            Assert.IsInstanceOf<RestaurantViewModel>(actualResult);
        }

        [Test]
        public void RestaurantViewModelBuilderBuildReturnExpectedResult()
        {
            var restaurantViewModelBuilder = new RestaurantViewModelBuilder();
            var actualResult = restaurantViewModelBuilder.Build(FakeRestaurant.GetResturantList());
            var expectedResult = GetRestaurantViewModel();
            expectedResult.Should().BeEquivalentTo(actualResult);

        }

        private RestaurantViewModel GetRestaurantViewModel()
        {
            return new RestaurantViewModel()
            {
                RestaurantList = GetRestaurantModelList()
            };
        }

        private IEnumerable<RestaurantModel> GetRestaurantModelList()
        {
            return new List<RestaurantModel>()
            {
                new RestaurantModel()
                {
                    RestaurantName="Resturant1",
                    Rating = "5.5",
                    CuisineList = new List<string>(){ "Pizza", "Chicken" }
                },
                new RestaurantModel()
                {
                    RestaurantName="Resturant2",
                    Rating = "4.5",
                    CuisineList = new List<string>(){ "Pizza", "Chicken" }
                }
            };
        }

    }
}
