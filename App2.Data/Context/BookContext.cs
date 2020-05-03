using App2.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Data.Context
{
    public class BookContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=XQW-BILGISAYAR\SQLEXPRESS;Database=BookDb;uid=sa;pwd=12345;Integrated security=true");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Book> Books { get; set; }
    }
}
