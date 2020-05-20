using App2.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Data.Context
{
    public class BookShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Server=XQW-BILGISAYAR\SQLEXPRESS;Database=BookDb;uid=sa;pwd=12345;Integrated security=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relation Key tanımlamalar BookAuthor'un Primary Key'i
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });

            //book tablosu bookauthor'a nasıl bağlanacak
            // Relation Key tanımlamalar BookAuthor'un FK'si / BookAuthor -> Book
            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);

            //author tablosu bookauthor'a nasıl bağlanacak
            // Relation Key tanımlamalar BookAuthor'un FK'si / BookAuthor -> Author
            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);

            modelBuilder.Entity<Book>()
                .HasOne(x => x.Publisher);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
    }
}
