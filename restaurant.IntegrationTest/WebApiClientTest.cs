using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using restaurant.Utilities;
using NUnit.Framework;

namespace restaurant.IntegrationTest
{
    [TestFixture]
    [Parallelizable]
    [ExcludeFromCodeCoverage]
    public class WebApiClientTest
    {
        [Test]
        public async Task GetAsync_Should_Return_OKStatus()
        {
            //Arrange
            var postCode = "se19";
            Uri uri = new Uri($"https://public.je-apis.com/restaurants?q={ postCode }");
            var httpRequestBuilder = new HttpRequestBuilder();
            var webApiClient = new WebApiClient(httpRequestBuilder);

            //Act
            var response = await webApiClient.GetAsync(uri, GetHeader());

            //Assert
            Assert.AreEqual(HttpStatusCode.OK,response.StatusCode);
        }


        [Test]
        public async Task GetAsync_Should_Return_Status_BadRequest()
        {
            //Arrange
            var postCode = "se19";
            Uri uri = new Uri($"https://public.je-apis.com/restaurants?q={ postCode }");
            var httpRequestBuilder = new HttpRequestBuilder();
            var webApiClient = new WebApiClient(httpRequestBuilder);
            var headers = GetHeader();
            headers[DefaultApiHeaderConstants.Authorization] = "somthing";

            //Act
            var response = await webApiClient.GetAsync(uri, headers);

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        private Dictionary<string, string> GetHeader()
        {
            return new Dictionary<string, string>
            {
                [DefaultApiHeaderConstants.Authorization] = "Basic VGVjaFRlc3Q6bkQ2NGxXVnZreDVw",
                [DefaultApiHeaderConstants.Tenant] = "uk",
                [DefaultApiHeaderConstants.Language] = "en-GB",
                [DefaultApiHeaderConstants.Host] = "public.je-apis.com"

            };
        }
    }
}
