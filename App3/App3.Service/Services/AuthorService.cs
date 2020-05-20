using App3.Data.Context;
using App3.Data.Entities;
using App3.Service.Dto;
using System;
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

        public Author GetById(int id)
        {
            return _context.Author.FirstOrDefault(author => author.Id == id);
        }

        public List<Author> GetAll() 
        {
            return _context.Author.ToList();
        }

        public void Update(Author entityToBeUpdate)
        {
            _context.Author.Update(entityToBeUpdate);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            //clear relations before delete author
            var blogs = _context.Blog.Where(blog => blog.AuthorId == id);
            foreach (var b in blogs)
            {
                b.AuthorId = null;
                _context.Blog.Update(b);
            }
            _context.SaveChanges();
            //delete author
            var entity = _context.Author.FirstOrDefault(x => x.Id == id);
            _context.Remove(entity);
            _context.SaveChanges();
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

        /// <summary>
        /// author ve blog tablolarını birleştir ve istenen alanları çek
        /// </summary>
        /// <returns></returns>
        public List<AuthorBlogSummaryDto> GetSummary()
        {
            var result = _context.Author.Join(_context.Blog,
                                              author => author.Id,
                                              blog => blog.AuthorId,
                                              (author, blog) => new AuthorBlogSummaryDto
                                              {
                                                  BlogId = blog.Id,
                                                  AuthorNameSurname = author.Name + " " + author.Surname,
                                                  BlogTitle = blog.Title,
                                                  CreateDate = blog.CreateDate
                                              }).ToList();

            return result;
        }
    }
}
