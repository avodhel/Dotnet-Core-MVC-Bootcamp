using App3.Data.Context;
using App3.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace App3.Logging
{
    public static class AppLogger
    {
        public static void AddLog(Log log)
        {
            var configurationBuilder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json");

            var configuration = configurationBuilder.Build();

            var dbContextOptionBuilder = new DbContextOptionsBuilder<BlogDbContext>();
            dbContextOptionBuilder.UseSqlServer(configuration.GetConnectionString("BlogDbContext"));
            using (BlogDbContext context = new BlogDbContext(dbContextOptionBuilder.Options))
            {
                context.Log.Add(log);
                context.SaveChanges();
            }
        }
    }
}
