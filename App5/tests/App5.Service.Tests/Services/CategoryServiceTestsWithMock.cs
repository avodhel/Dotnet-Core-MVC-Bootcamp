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
    public class CategoryServiceTestsWithMock
    {
        [Fact]
        public void GetCategoriesShouldNotReturnNull()
        {
            //Arrange 
            var categoryList = new List<Category>() {
                new Category()
                {
                    Id=1,
                    Name="Cep Telefonu"
                }
            };

            var categoryDbSetMock = TestHelper.GetDbSetMock(categoryList);

            var contextMock = new Mock<ECommerceContext>(new DbContextOptions<ECommerceContext>());
            contextMock.Setup(x => x.Category).Returns(categoryDbSetMock.Object);

            var categoryService = new CategoryService(contextMock.Object);

            // Act
            var categories = categoryService.GetCategories();

            // Assert
            Assert.NotNull(categories);
        }
    }
}
