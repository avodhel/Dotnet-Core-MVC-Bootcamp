using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using App2.Data.Entities;
using App2.Models;
using App2.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace App2.Controllers
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

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AuthorInsertViewModel model)
        {
            var entity = _mapper.Map<Author>(model);
            var affedtedRowCount = _service.Add(entity);
            ViewBag.AffectedRowCount = affedtedRowCount;
            return View(model);
        }

        public IActionResult Update(int id)
        {
            var entity = _service.GetById(id);
            var model = _mapper.Map<AuthorUpdateViewModel>(entity);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(AuthorUpdateViewModel model)
        {
            var entity = _mapper.Map<Author>(model);
            var affectedRowCount = _service.Update(entity);
            ViewData["UpdateAffectedRowCount"] = affectedRowCount;
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var author = _service.GetById(id);
            var model = _mapper.Map<AuthorDetailViewModel>(author);
            return View(model);
        }
    }
}