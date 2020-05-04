using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using App2.Data.Entities;
using App2.Models;
using App2.Service;
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
            return View();
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
    }
}