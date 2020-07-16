using App5.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App5.Data.Context
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
