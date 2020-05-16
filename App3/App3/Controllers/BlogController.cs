using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App3.Models;
using App3.Service.Dto;
using App3.Service.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App3.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogService _service;
        private readonly IMapper _mapper;
        public BlogController(BlogService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IActionResult Index(int tagId, int pageId = 1)
        {
            var blogs = new BlogPaginationDto();
            if (tagId > 0)
            {
                blogs = _service.GetByTagId(tagId, pageId);
            }
            else
            {
                blogs = _service.GetBlogs(pageId);
            }

            var models = _mapper.Map<BlogPaginationViewModel>(blogs);
            if (tagId > 0)
            {
                models.TagId = tagId;
            }

            return View(models);
        }

        public IActionResult Detail(int id)
        {
            var blog = _service.GetById(id);
            var model = _mapper.Map<BlogViewModel>(blog);

            return View(model);
        }
    }
}