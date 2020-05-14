using App3.Data.Context;
using App3.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace App3.Service.Services
{
    public class AuthorService
    {
        private readonly BlogDbContext _context;
        public AuthorService(BlogDbContext context)
        {
            _context = context;
        }

        public List<Author> GetAll() {
            return _context.Author.ToList();
        }
    }
}
