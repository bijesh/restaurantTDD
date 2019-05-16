using restaurant.Contract;
using restaurant.Controllers;
using restaurant.Interface;
using restaurant.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FluentAssertions;
using FluentAssertions.Common;

namespace restaurant.Test
{
    [TestFixture]
    [Parallelizable]
    [ExcludeFromCodeCoverage]
    public class RestaurantControllerTests
    {

        private RestaurantController restaurantController;
        private Mock<IRestaurantService> restaurantServiceMock;
        private Mock<IRestaurantViewModelBuilder> restaurantViewModelBuilderMock;

        [SetUp]
        public virtual void SetUp()
        {
            restaurantServiceMock = new Mock<IRestaurantService>();
            restaurantServiceMock.Setup(i => i.SearchRestaurants(It.IsAny<string>())).ReturnsAsync(new List<Restaurant>());
            restaurantViewModelBuilderMock = new Mock<IRestaurantViewModelBuilder>();
            restaurantViewModelBuilderMock.Setup(i => i.Build(It.IsAny<IEnumerable<Restaurant>>())).Returns(new RestaurantViewModel());
            restaurantController = new RestaurantController(restaurantServiceMock.Object, restaurantViewModelBuilderMock.Object);
        }

       
        [Test]
        public void WhenRequestingRestaurantPageThenReturnIndexView()
        {
            //Act
            var viewResult = restaurantController.Index() as ViewResult;

            //Assert
            Assert.AreEqual("Index", viewResult?.ViewName);

        }

        [Test]
        public void WhenRestaurantServiceIsnullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new RestaurantController(null, restaurantViewModelBuilderMock.Object));
        }

        [Test]
        public void WhenRestaurantViewModelBuildersIsnullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new RestaurantController(null, restaurantViewModelBuilderMock.Object));
        }

        [Test]
        public async Task WhenCallingRestaurantSearchThenReturnInstanceOfRestaurantViewModel()
        {
            //Arrange
            var postCode = "se19";

            //Act
            var viewResult = await restaurantController.Search(postCode) as ViewResult;

            //Assert
            Assert.IsInstanceOf<ViewResult>(viewResult);
            Assert.IsInstanceOf<RestaurantViewModel>(viewResult?.Model);
        }

        [Test]
        public async Task WhenCallingRestaurantSearchWithNullPostCodeThenReturnErrorView()
        {
            //Arrange
            
            restaurantServiceMock.Setup(i => i.SearchRestaurants(It.IsAny<string>())).Throws(new Exception());
            restaurantViewModelBuilderMock.Setup(i => i.Build(It.IsAny<IEnumerable<Restaurant>>())).Returns(new RestaurantViewModel());
            restaurantController = new RestaurantController(restaurantServiceMock.Object, restaurantViewModelBuilderMock.Object);
            var postCode = "se19";

            //Act

            var viewResult = await restaurantController.Search(postCode) as ViewResult;

            //Assert
            Assert.AreEqual("Error", viewResult?.ViewName);
        }

        [Test]
        public async Task WhenCallingRestaurantSearchWithPostCodeThenReturnExpectedResults()
        {
            //Arrange
            var postCode = "se19";

            //Act
            var viewResult = await restaurantController.Search(postCode) as ViewResult;

            //Assert
            Assert.IsInstanceOf<ViewResult>(viewResult);
            Assert.IsInstanceOf<RestaurantViewModel>(viewResult?.Model);
        }
    }
}
