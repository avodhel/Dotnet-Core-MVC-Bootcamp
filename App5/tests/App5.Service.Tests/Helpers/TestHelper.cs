using App5.Data.Context;
using Microsoft.EntityFrameworkCore;
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
    }
}
