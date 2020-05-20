using App3.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace App3.Data.Context
{
    public class BlogDbContext: DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }

        //define two keys for blogtag entity 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogTag>()
                .HasKey(bt => new { bt.BlogId, bt.TagId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Blog> Blog { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<BlogTag> BlogTag { get; set; }
        public DbSet<Log> Log { get; set; }
    }
}

