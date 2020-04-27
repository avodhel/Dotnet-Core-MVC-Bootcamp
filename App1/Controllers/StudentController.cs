using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App1.Entities;
using App1.Models;
using App1.Services;
using Microsoft.AspNetCore.Mvc;

namespace App1.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _service;
        public StudentController(StudentService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var entities = _service.GetAllStudent();
            var students = entities.Select(x => new StudentViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Class = x.Surname,
                Teacher = x.Teacher
            }).ToList();
            return View(students);
        }

        [HttpGet("ogrenci/{id}")]
        public IActionResult Edit(int id)
        {
            var studentEntity = _service.Get(id);
            var model = new StudentViewModel
            {
                Id = studentEntity.Id,
                Name = studentEntity.Name,
                Surname = studentEntity.Surname,
                Class = studentEntity.Class,
                Teacher = studentEntity.Teacher
            };
            return View(model);
        }

        [HttpPost]
        public JsonResult Edit(StudentViewModel model)
        {
            var studentEntity = new StudentEntity
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Class = model.Class,
                Teacher = model.Teacher
            };
            _service.Edit(studentEntity);
            return new JsonResult(new
            {
                StatusCode = 200,
                Value = "Güncelleme başarılı"
            });
        }
    }
}