using App3.Data.Context;
using App3.Data.Entities;
using App3.Service.Dto;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App3.Service.Services
{
    public class BlogService
    {
        private readonly BlogDbContext _context;
        public BlogService(BlogDbContext context)
        {
            _context = context;
        }
        public List<BlogDto> GetBlogs()
        {
            var result = _context.Blog.Join(_context.Author,
                                            blog => blog.AuthorId,
                                            author => author.Id,
                                            (blog, author) => new { blog, author })
                                       .Select(result => new BlogDto
                                       {
                                           Id = result.blog.Id,
                                           Title = result.blog.Title,
                                           Content = result.blog.Content,
                                           CreateDate = result.blog.CreateDate,
                                           DislikeCount = result.blog.DislikeCount,
                                           LikeCount = result.blog.LikeCount,
                                           Author = new AuthorInfoDto
                                           {
                                               Id = result.author.Id,
                                               NameAndSurname = $"{result.author.Name}{result.author.Surname}",
                                           }
                                       })
                                       .ToList();

            foreach (var blog in result)
            {
                var tags = _context.Tag.Join(_context.BlogTag,
                                             tag => tag.Id,
                                             blogTag => blogTag.TagId,
                                             (tag, blogTag) => new { tag, blogTag.BlogId })
                                        .Where(query => query.BlogId == blog.Id)
                                        .Select(result => new TagDto
                                        {
                                            Id = result.tag.Id,
                                            Name = result.tag.Name
                                        })
                                        .ToList();
                blog.Tags = tags;
            }

            return result;
        }
    }
}
