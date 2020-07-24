using App5.Api.Integration.Tests.Infrastructure;
using App5.Service.Model.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace App5.Api.Integration.Tests
{
    public class ProductTests : TestFixture
    {
        public ProductTests(TestWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task GetAllShouldReturnSuccessStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var productListResponse = client.GetAsync("/Product/GetAll");

            // Assert
            Assert.Equal(HttpStatusCode.OK, productListResponse.Result.StatusCode);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(6)]
        public async Task GetProductByIdShouldReturnSuccessStatusCode(int productId)
        {

            // Arrange
            var client = _factory.CreateClient();

            // Act
            var productListResponse = client.GetAsync($"/Product/Get/{productId}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, productListResponse.Result.StatusCode);
        }

        [Fact]
        public async Task UpdateProductShouldReturnSuccessStatusCode()
        {
            // Arrange
            var productUpdateRequest = new ProductUpdateRequest()
            {
                Id = 6,
                Price = 50,
                StockCount = 100
            };

            var contentJson = JsonConvert.SerializeObject(productUpdateRequest);
            var stringContent = new StringContent(contentJson, Encoding.UTF8, "application/json");

            var client = _factory.CreateClient();

            // Act
            var response = await client.PutAsync("/Product/Update", stringContent);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task UpdateProductShouldReturnNotFoundStatusCode()
        {
            // Arrange
            var productUpdateRequest = new ProductUpdateRequest()
            {
                Id = -1,
                Price = 50,
                StockCount = 100
            };

            var contentJson = JsonConvert.SerializeObject(productUpdateRequest);
            var stringContent = new StringContent(contentJson, Encoding.UTF8, "application/json");

            var client = _factory.CreateClient();

            // Act
            var response = await client.PutAsync("/Product/Update", stringContent);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task QueryShouldReturnHttpSuccessStatusCode()
        {
            // Arrange
            var queryRequest = new ProductQueryRequest()
            {
                Id = 4,
                Brand = "test"
            };

            var contentJson = JsonConvert.SerializeObject(queryRequest);
            var stringContent = new StringContent(contentJson, Encoding.UTF8, "application/json");

            var client = _factory.CreateClient();

            // Act
            var response = await client.PostAsync("/Product/Query", stringContent);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
