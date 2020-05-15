using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using App3.Service.Services;
using App3.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}