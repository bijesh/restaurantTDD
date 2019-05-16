using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using restaurant.Contract;
using restaurant.Interface;
using restaurant.Services;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace restaurant.Test
{
    [TestFixture]
    [Parallelizable]
    [ExcludeFromCodeCoverage]
    public class RestaurantServiceTests
    {
        private Mock<IWebApiClient> webApiClientMock;
        private RestaurantService restaurantService;

        [SetUp]
        public virtual void SetUp()
        {
            webApiClientMock = new Mock<IWebApiClient>();
           // webApiClientMock.Setup(i => i.GetAsync<IEnumerable<Restaurant>>(It.IsAny<string>())).ReturnsAsync(new List<Restaurant>());
            webApiClientMock.Setup(i => i.GetAsync(It.IsAny<Uri>(),It.IsAny<Dictionary<string,string>>())).ReturnsAsync(GetResponse);
            restaurantService = new RestaurantService(webApiClientMock.Object);
        }

        [Test]
        public async Task WhenCallingSearchRestaurantsReturnsExpectedInstance()
        {
            var postCode = "se19";
            var result = await restaurantService.SearchRestaurants(postCode);
            Assert.IsInstanceOf<IEnumerable<Restaurant>>(result);
        }

        [Test]
        public async Task WhenCallingSearchRestaurantsReturnsExpectedRestaurantCount()
        {
            var postCode = "se19";
            var result = await restaurantService.SearchRestaurants(postCode);
            Assert.AreEqual(263, result.Count());

        }

        [Test]
        public async Task WhenCallingSearchRestaurantsReturnNull()
        {
            webApiClientMock.Setup(i => i.GetAsync(It.IsAny<Uri>(), It.IsAny<Dictionary<string, string>>())).ReturnsAsync(new HttpResponseMessage{StatusCode = HttpStatusCode.BadGateway});
            var postCode = "se19";
            var result = await restaurantService.SearchRestaurants(postCode);
            Assert.IsNull(result);

        }
        private HttpResponseMessage GetResponse()
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(GetJson(), Encoding.UTF8, "application/json")
            };
        }

        private string GetJson()
        {
            var path = System.AppContext.BaseDirectory;
            var streamReader = new StreamReader(@path + "Restaurants.json", Encoding.UTF8);
            return streamReader.ReadToEnd();
        }



    }
}
