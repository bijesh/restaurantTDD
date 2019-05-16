using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using restaurant.Utilities;
using Moq;
using NUnit.Framework;

namespace restaurant.Test
{
    [TestFixture]
    [Parallelizable]
    [ExcludeFromCodeCoverage]
    public class HttpRequestBuilderTests
    {
        private HttpRequestBuilder _httpRequestBuilder;

        [SetUp]
        public void Setup()
        {
            _httpRequestBuilder = new HttpRequestBuilder();
        }

        [Test]
        public void GetHttpRequestMessage_Returns_HttpRequestMessage()
        {
            Assert.IsNotNull(_httpRequestBuilder.GetHttpRequestMessage(It.IsAny<Uri>(), It.IsAny<IDictionary<string, string>>(),
                HttpMethod.Get));
        }

        [Test]
        public void GetHttpRequestMessage_Sets_Request_Uri()
        {
            var requestMessage = _httpRequestBuilder.GetHttpRequestMessage(new Uri("http://localhost"), It.IsAny<IDictionary<string, string>>(),
                HttpMethod.Get);
            Assert.IsNotNull(requestMessage.RequestUri);
        }

        [Test]
        public void GetHttpRequestMessage_Sets_HttpMethod()
        {
            var requestMessage = _httpRequestBuilder.GetHttpRequestMessage(new Uri("http://localhost"), It.IsAny<IDictionary<string, string>>(),
                HttpMethod.Get);
            Assert.IsNotNull(requestMessage.Method);
        }

        [Test]
        public void GetHttpRequestMessage_Sets_ContentTypeHeader()
        {
            var requestMessage = _httpRequestBuilder.GetHttpRequestMessage(new Uri("http://localhost"), It.IsAny<IDictionary<string, string>>(),
                HttpMethod.Get);
            Assert.IsTrue(requestMessage.Headers.Accept.Any(x => x.MediaType == "application/json"));
        }

        [Test]
        public void GetHttpRequestMessage_Sets_ApiRequestHeaders()
        {
            var requestMessage = _httpRequestBuilder.GetHttpRequestMessage(new Uri("http://localhost"), new Dictionary<string, string>
            {
                [DefaultApiHeaderConstants.Authorization] = "something",
                [DefaultApiHeaderConstants.Tenant] = "something",
                [DefaultApiHeaderConstants.Language] = "something",
                [DefaultApiHeaderConstants.Host] = "something"

            },
                HttpMethod.Get);
            Assert.IsTrue(requestMessage.Headers.Any(x => x.Key == DefaultApiHeaderConstants.Authorization));
            Assert.IsTrue(requestMessage.Headers.Any(x => x.Key == DefaultApiHeaderConstants.Tenant));
            Assert.IsTrue(requestMessage.Headers.Any(x => x.Key == DefaultApiHeaderConstants.Language));
            Assert.IsTrue(requestMessage.Headers.Any(x => x.Key == DefaultApiHeaderConstants.Host));
        }

    }
}
