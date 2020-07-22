using App5.Data.Context;
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
    }
}
