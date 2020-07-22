using App5.Data.Context;
using App5.Service.Model.Request;
using App5.Service.Services;
using App5.Service.Tests.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace App5.Service.Tests.Services
{
    public class ProductServiceTests
    {
        [Fact]
        public void GetAllProductsShouldNotReturnEmpty()
        {
            // Arrange
            var context = TestHelper.GetContext();
            var productService = new ProductService(context);

            // Act
            var products = productService.GetAll();

            // Assert
            Assert.NotEmpty(products);
        }

        //Theory ile test metodu içeride verilen id'lere özel olarak birden fazla kez çalıştırılabilir
        // 4 ve 5 id'li veriler için çalışır
        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        public void GetProductByIdShouldNotReturnNull(int productId)
        {
            // Arrange
            var context = TestHelper.GetContext();
            var productService = new ProductService(context);

            // Act
            var product = productService.Get(productId);

            // Assert
            Assert.NotNull(product);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        public void GetProductByIdShouldReturnNull(int productId)
        {
            // Arrange
            var context = TestHelper.GetContext();
            var productService = new ProductService(context);

            // Act
            var product = productService.Get(productId);

            // Assert
            Assert.Null(product);
        }

        [Fact]
        public void UpdateShouldSuccess()
        {
            // Arrange
            var context = TestHelper.GetContext();
            var productService = new ProductService(context);
            var productUpdateRequest = new ProductUpdateRequest()
            {
                Id = 5,
                Price = 12,
                StockCount = 150
            };

            // Act
            var affectedRowCount = productService.Update(productUpdateRequest);

            // Assert
            Assert.True(affectedRowCount > 0);
        }

        [Fact]
        public void UpdateShouldFail()
        {
            // Arrange
            var context = TestHelper.GetContext();
            var productService = new ProductService(context);
            var productUpdateRequest = new ProductUpdateRequest()
            {
                Id = -1,
                Price = 25,
                StockCount = 150
            };

            // Act
            var affectedRowCount = productService.Update(productUpdateRequest);

            // Assert
            Assert.Equal(-1, affectedRowCount);
        }
    }
}
