using App5.Data.Context;
using App5.Data.Entities;
using App5.Service.Services;
using App5.Service.Tests.Helpers;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace App5.Service.Tests.Services
{
    public class ProductServiceTestsWithMock
    {
        [Fact]
        public void GetAllProductsShouldNotReturnEmpty()
        {
            // Arrange
            var productList = new List<Product>()
            {
                new Product()
                {
                    Id=1,
                    Name="Bardak Altlığı",
                    Brand="Madame Coco"
                }
            };

            var productDbSetMock = TestHelper.GetDbSetMock(productList);

            var contextMock = new Mock<ECommerceContext>(new DbContextOptions<ECommerceContext>());
            contextMock.Setup(x => x.Product).Returns(productDbSetMock.Object);

            var productService = new ProductService(contextMock.Object);

            // Act
            var products = productService.GetAll();

            // Assert
            Assert.NotNull(products);
        }

        [Fact]
        public void GetProductByIdShouldReturnGivenName()
        {
            int testProductId = 1;
            string expectedProductName = "Bardak Altlığı";
            var productList = new List<Product>()
            {
                new Product()
                {
                    Id=testProductId,
                    Name=expectedProductName,
                    Brand="Madame Coco"
                },
                new Product()
                {
                    Id=5,
                    Name="Kareli Defter",
                    Brand="Levent"
                }
            };

            var productDbSetMock = TestHelper.GetDbSetMock(productList);

            var contextMock = new Mock<ECommerceContext>(new DbContextOptions<ECommerceContext>());
            contextMock.Setup(x => x.Product).Returns(productDbSetMock.Object);

            var productService = new ProductService(contextMock.Object);

            // Act
            var product = productService.Get(testProductId);

            // Assert
            Assert.Equal(expectedProductName, product.Name);
        }
    }
}
