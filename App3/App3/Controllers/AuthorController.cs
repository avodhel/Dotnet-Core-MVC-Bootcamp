﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using App3.Service.Services;
using App3.Models;
using Microsoft.AspNetCore.Mvc;
using App3.Service.Dto;
using App3.Data.Entities;

namespace App3.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AuthorService _service;
        private readonly IMapper _mapper;
        public AuthorController(AuthorService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var authors = _service.GetAll();
            var model = _mapper.Map<List<AuthorIndexViewModel>>(authors);
            return View(model);
        }

        public IActionResult Query(int blogCount)
        {
            var authors = _service.BlogCountQuery(blogCount);
            var model = _mapper.Map<List<AuthorIndexViewModel>>(authors);
            return View("Index", model);
        }

        public IActionResult Summary()
        {
            var summaryDto = _service.GetSummary();
            var model = _mapper.Map<List<AuthorBlogSummaryViewModel>>(summaryDto);
            return View(model);
        }

        public IActionResult Update(int id)
        {
            var author = _service.GetById(id);
            var model = _mapper.Map<AuthorViewModel>(author);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(AuthorViewModel model)
        {
            var entity = _mapper.Map<Author>(model);
            _service.Update(entity);
            return RedirectToAction("Index", "Author");
        }

        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index), "Author");
        }

        public IActionResult Detail(int id)
        {
            var author = _service.GetById(id);
            var model = _mapper.Map<AuthorViewModel>(author);
            return View(model);
        }
    }
}