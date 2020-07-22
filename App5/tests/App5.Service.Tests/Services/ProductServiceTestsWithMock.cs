using App5.Data.Context;
using App5.Data.Entities;
using App5.Service.Model.Request;
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

        [Fact]
        public void UpdateShouldSuccess()
        {
            // Arrange
            var productList = new List<Product>()
            {
                new Product()
                {
                    Id=6,
                    Name="Test",
                    StockCount=0,
                    Price=10
                }
            };

            var productDbSetMock = TestHelper.GetDbSetMock(productList);

            var contextMock = new Mock<ECommerceContext>(new DbContextOptions<ECommerceContext>());
            contextMock.Setup(x => x.Product).Returns(productDbSetMock.Object);
            contextMock.Setup(x => x.SaveChanges()).Returns(1);

            var productService = new ProductService(contextMock.Object);


            var productUpdateRequest = new ProductUpdateRequest()
            {
                Id = 6,
                Price = 25,
                StockCount = 150
            };

            // Act
            var affectedRowCount = productService.Update(productUpdateRequest);

            // Assert
            Assert.True(affectedRowCount > 0);

            //test çalıştığında herhangi bir product bir kez updatelenmiş olmalı
            contextMock.Verify(x => x.Product.Update(It.IsAny<Product>()), Times.Once);
            //test çalıştığında mock üzerindeki savechanges bir kere çağrılmış olmalı
            contextMock.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
