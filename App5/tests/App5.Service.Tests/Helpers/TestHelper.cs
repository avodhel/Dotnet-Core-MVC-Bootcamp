using App5.Data.Context;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App5.Service.Tests.Helpers
{
    public class TestHelper
    {
        public static ECommerceContext GetContext()
        {
            var builder = new DbContextOptionsBuilder<ECommerceContext>()
                .UseSqlServer("Server=XQW-BILGISAYAR\\SQLEXPRESS;Database=ECommerceDb;uid=sa;pwd=12345;Integrated security=true;MultipleActiveResultSets=true");
            return new ECommerceContext(builder.Options);
        }

        // dışarıdan aldığı list'e göre içeride mock dbset üreten ve gönderen metod
        public static Mock<DbSet<T>> GetDbSetMock<T>(IEnumerable<T> list) where T : class
        {
            var listQueryable = list.AsQueryable();
            var dbSetMock = new Mock<DbSet<T>>();

            dbSetMock.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(listQueryable.GetEnumerator());
            dbSetMock.As<IQueryable<T>>().Setup(x => x.Expression).Returns(listQueryable.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(listQueryable.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.Provider).Returns(listQueryable.Provider);

            return dbSetMock;
        }
    }
}
