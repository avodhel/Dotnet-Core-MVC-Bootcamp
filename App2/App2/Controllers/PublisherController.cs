using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using App2.Data.Entities;
using App2.Models;
using App2.Service.Services;
using App2.Data.Repositories;

namespace App2.Controllers
{
    public class PublisherController : Controller
    {
        private readonly PublisherService _publisherService;
        private readonly IMapper _mapper;
        public PublisherController(PublisherService service, IMapper mapper)
        {
            _publisherService = service;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var publishers = _publisherService.GetAll();
            var model = _mapper.Map<List<PublisherIndexViewModel>>(publishers);
            return View(model);
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(PublisherInsertViewModel model)
        {
            var entity = _mapper.Map<Publisher>(model);
            _publisherService.Insert(entity);
            return View(model);
        }

        public IActionResult Update(int id)
        {
            var entity = _publisherService.GetById(id);
            var model = _mapper.Map<PublisherUpdateViewModel>(entity);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(PublisherUpdateViewModel model)
        {
            var entity = _mapper.Map<Publisher>(model);
            _publisherService.Update(entity);
            return View(model);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var publisher = _publisherService.GetById(id);
            var model = _mapper.Map<PublisherDetailViewModel>(publisher);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _publisherService.Delete(id);
            return RedirectToAction("Index", "Publisher");
        }
    }
}