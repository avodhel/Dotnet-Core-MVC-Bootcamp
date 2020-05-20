using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App3.Filters;
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

        [ExceptionLogFilter]
        [ServiceFilter(typeof(CustomResultFilter))]
        public IActionResult Index(int tagId, int pageId = 1)
        {
            if (tagId < 0)
            {
                throw new Exception($"tagId 0'dan küçük olamaz. Şuan ki değer : {tagId}");
            }
            if (pageId < 1)
            {
                throw new Exception($"pageId 1'den küçük olamaz. Şuan ki değer : {pageId}");
            }

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

        [ServiceFilter(typeof(CustomActionFilter), Order = 3)]
        [ServiceFilter(typeof(CustomHeaderActionFilter), Order = 2)]
        [ServiceFilter(typeof(ViewDataActionFilter), Order = 1)]
        public IActionResult Detail(int id)
        {
            var blog = _service.GetById(id);
            var model = _mapper.Map<BlogViewModel>(blog);

            return View(model);
        }

        [ServiceFilter(typeof(CustomHeaderActionFilter))]
        public JsonResult Like(int id)
        {
            var likeCount = _service.Like(id);
            return Json(likeCount);
        }

        public JsonResult Dislike(int id)
        {
            var dislikeCount = _service.Dislike(id);
            return Json(dislikeCount);
        }
    }
}