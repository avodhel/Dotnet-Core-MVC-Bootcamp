﻿using App3.Data.Context;
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
        private readonly int BlogCountPerPage = 3;
        public BlogService(BlogDbContext context)
        {
            _context = context;
        }
        public BlogPaginationDto GetBlogs(int pageId)
        {
            var blogs = _context.Blog.Join(_context.Author,
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
                                             NameAndSurname = $"{result.author.Name} {result.author.Surname}",
                                         }
                                     })
                                    .Skip((pageId - 1) * BlogCountPerPage)
                                    .Take(BlogCountPerPage)
                                    .ToList();

            foreach (var blog in blogs)
            {
                var tags = GetTags(blog.Id);
                blog.Tags = tags;
            }
            var blogCount = _context.Blog.Count();
            return new BlogPaginationDto
            {
                Blogs = blogs,
                BlogPageCount = GetPageCount(blogCount)
            };
        }

        public BlogDto GetById(int id)
        {
            var result = _context.Blog.Join(_context.Author,
                                            blog => blog.AuthorId,
                                            author => author.Id,
                                            (blog, author) => new { blog, author })
                                        .Where(x => x.blog.Id == id)
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
                                                NameAndSurname = $"{result.author.Name} {result.author.Surname}",
                                            }
                                        })
                                        .FirstOrDefault();

            var tags = GetTags(result.Id);
            result.Tags = tags;
            return result;
        }

        public BlogPaginationDto GetByTagId(int tagId, int pageId)
        {
            var result = _context.Blog.Join(_context.Author,
                                            blog => blog.AuthorId,
                                            author => author.Id,
                                            (blog, author) => new { blog, author })
                                      .Join(_context.BlogTag,
                                            query => query.blog.Id,
                                            blogTag => blogTag.BlogId,
                                            (query, blogTag) => new { query.blog, query.author, blogTag.TagId })
                                      .Where(x => x.TagId == tagId)
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
                                               NameAndSurname = $"{result.author.Name} {result.author.Surname}",
                                           }
                                       })
                                      .Skip((pageId - 1) * BlogCountPerPage)
                                      .Take(BlogCountPerPage)
                                      .ToList();

            foreach (var blog in result)
            {
                blog.Tags = GetTags(blog.Id);
            }

            int blogCount = _context.Blog.Join(_context.BlogTag,
                                               blog => blog.Id,
                                               blogTag => blogTag.BlogId,
                                               (blog, blogTag) => new { blog.Id, blogTag.TagId })
                                         .Where(x => x.TagId == tagId)
                                         .Count();

            return new BlogPaginationDto
            {
                Blogs = result,
                BlogPageCount = GetPageCount(blogCount)
            };
        }
        private List<TagDto> GetTags(int blogId)
        {
            return _context.Tag.Join(_context.BlogTag,
                                    tag => tag.Id,
                                    blogTag => blogTag.TagId,
                                    (tag, blogtag) => new { tag, blogtag.BlogId })
                                .Where(query => query.BlogId == blogId)
                                .Select(result => new TagDto
                                    {
                                        Id = result.tag.Id,
                                        Name = result.tag.Name
                                    })
                                .ToList();
        }

        private int GetPageCount(int blogCount)
        {
            int pageCount = 0;
            if (blogCount % BlogCountPerPage == 0)
            {
                pageCount = blogCount / BlogCountPerPage;
            }
            else
            {
                pageCount = blogCount / BlogCountPerPage + 1;
            }
            return pageCount;
        }

        public int Like(int id)
        {
            var blog = _context.Blog.FirstOrDefault(x => x.Id == id);
            blog.LikeCount++;
            _context.Blog.Update(blog);
            _context.SaveChanges();
            return blog.LikeCount;
        }
        public int Dislike(int id)
        {
            var blog = _context.Blog.FirstOrDefault(x => x.Id == id);
            blog.DislikeCount++;
            _context.Blog.Update(blog);
            _context.SaveChanges();
            return blog.DislikeCount;
        }
    }
}
