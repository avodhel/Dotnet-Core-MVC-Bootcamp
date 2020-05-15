﻿using App3.Data.Context;
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

        /// <summary>
        /// bütün yazarlar için belli bir sayıda yazısı olanları dön
        /// </summary>
        /// <param name="blogCount"></param>
        /// <returns></returns>
        public List<Author> BlogCountQuery(int blogCount)
        {
            List<int> authorIds = _context.Author.Join(_context.Blog, 
                                                        author => author.Id,
                                                        blog => blog.AuthorId,
                                                        (author, blog) => new {
                                                            AuthorId = author.Id,
                                                            BlogId = blog.Id
                                                        })
                                                .GroupBy(query => query.AuthorId)
                                                .Select(x => new { x.Key, Count = x.Count()})
                                                .Where(query => query.Count > blogCount)
                                                .Select(result => result.Key)
                                                .ToList();

            return _context.Author.Where(author => authorIds.Contains(author.Id)).ToList();
        }
    }
}
