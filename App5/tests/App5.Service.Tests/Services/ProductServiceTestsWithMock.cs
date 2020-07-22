using App5.Data.Context;
using App5.Data.Entities;
using App5.Service.Services;
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

            var productDbSetMock = new Mock<DbSet<Product>>();
            productDbSetMock.As<IQueryable<Product>>()
                .Setup(x => x.GetEnumerator())
                .Returns(productList.GetEnumerator());

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

            var productDbSetMock = new Mock<DbSet<Product>>();
            productDbSetMock.As<IQueryable<Product>>()
                .Setup(x => x.GetEnumerator())
                .Returns(productList.GetEnumerator());
            productDbSetMock.As<IQueryable<Product>>()
                .Setup(x => x.Expression)
                .Returns(productList.AsQueryable().Expression);
            productDbSetMock.As<IQueryable<Product>>()
                .Setup(x => x.ElementType)
                .Returns(productList.AsQueryable().ElementType);
            productDbSetMock.As<IQueryable<Product>>()
                .Setup(x => x.Provider)
                .Returns(productList.AsQueryable().Provider);

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
