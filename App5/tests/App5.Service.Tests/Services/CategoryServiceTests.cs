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
    public class CategoryServiceTests
    {
        //Fact ile buranın bir test metodu olduğunu belirtiyoruz.
        [Fact]
        public void GetCategoriesShouldNotReturnNull()
        {
            // Arrange(test için hazırlık aşaması)
            var context = TestHelper.GetContext();
            var categoryService = new CategoryService(context);

            // Act(Test kapsamında yapılacak işlerin belirtilmesi)
            var categories = categoryService.GetCategories();

            // Assert(doğrulama aşaması, test sonucunda beklentilerin karşılanıp karşılanmadığının kontrolü)
            Assert.NotNull(categories);
        }
    }
}
