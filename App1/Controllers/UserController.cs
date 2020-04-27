using System.Collections.Generic;
using App1.Entities;
using App1.Models;
using App1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace App1.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly UserService _service;
        public UserController(UserService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            List<UserViewModel> models = new List<UserViewModel>();
            var users = _service.GetAll();
            foreach (var user in users)
            {
                models.Add(new UserViewModel
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    BirthDate = user.BirthDate,
                    Email = user.Email,
                    Gender = user.Gender,
                    GithubAccountUrl = user.GithubAccountUrl
                });
            }

            return View(models);
        }
        public IActionResult IndexJs()
        {
            List<UserViewModel> models = new List<UserViewModel>();
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString("PageTimeStamp")))
            {
                HttpContext.Session.SetString("PageTimeStamp", DateTime.Now.ToString());
            }
            var users = _service.GetAll();
            foreach (var user in users)
            {
                models.Add(new UserViewModel
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    BirthDate = user.BirthDate,
                    Email = user.Email,
                    Gender = user.Gender,
                    GithubAccountUrl = user.GithubAccountUrl
                });
            }
            return View(models);
        }

        public IActionResult Add()
        {
            var model = new UserViewModel();
            SelectListItem[] genderList = new SelectListItem[]
            {
                new SelectListItem(){ Text="Seçiniz"},
                new SelectListItem(){Text="Kadın", Value="Female"},
                new SelectListItem(){Text="Erkek",Value="Male"}
            };
            //model.GenderSelectList = genderList;
            ViewBag.GenderList = genderList;
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(UserViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                SelectListItem[] genderList = new SelectListItem[]
                  {
                    new SelectListItem(){ Text="Seçiniz"},
                    new SelectListItem(){Text="Kadın", Value="Female"},
                    new SelectListItem(){Text="Erkek",Value="Male"}
                  };
                //model.GenderSelectList = genderList;
                ViewBag.GenderList = genderList;
                return View(model);
            }
            UserEntity entity = new UserEntity
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                BirthDate = model.BirthDate,
                Email = model.Email,
                GithubAccountUrl = model.GithubAccountUrl,
                Gender = model.Gender
            };
            _service.Add(entity);

            return RedirectToAction(nameof(Index), "User");
        }

        public IActionResult Get(int id)
        {
            var userEntity = _service.Get(id);
            var model = new UserViewModel()
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Surname = userEntity.Surname,
                BirthDate = userEntity.BirthDate,
                Email = userEntity.Email,
                Gender = userEntity.Gender,
                GithubAccountUrl = userEntity.GithubAccountUrl
            };
            return View(model);
        }

        public IActionResult GetAsJson(int id)
        {
            var userEntity = _service.Get(id);
            var model = new UserViewModel()
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Surname = userEntity.Surname,
                BirthDate = userEntity.BirthDate,
                Email = userEntity.Email,
                Gender = userEntity.Gender,
                GithubAccountUrl = userEntity.GithubAccountUrl
            };
            return Json(model);
        }

        [HttpGet("DetailEdit/{id}")]
        public IActionResult Edit(int id)
        {
            var userEntity = _service.Get(id);
            var model = new UserViewModel()
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Surname = userEntity.Surname,
                BirthDate = userEntity.BirthDate,
                Email = userEntity.Email,
                Gender = userEntity.Gender,
                GithubAccountUrl = userEntity.GithubAccountUrl
            };
            SelectListItem[] genderList = new SelectListItem[]
               {
                    new SelectListItem(){ Text="Seçiniz"},
                    new SelectListItem(){Text="Kadın", Value="Female"},
                    new SelectListItem(){Text="Erkek",Value="Male"}
               };
            //model.GenderSelectList = genderList;
            ViewData["GenderList"] = genderList;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                SelectListItem[] genderList = new SelectListItem[]
                  {
                    new SelectListItem(){ Text="Seçiniz"},
                    new SelectListItem(){Text="Kadın", Value="Female"},
                    new SelectListItem(){Text="Erkek",Value="Male"}
                  };
                //model.GenderSelectList = genderList;
                ViewData["GenderList"] = genderList;
                return View(model);
            }
            UserEntity entity = new UserEntity
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                BirthDate = model.BirthDate,
                Email = model.Email,
                GithubAccountUrl = model.GithubAccountUrl,
                Gender = model.Gender
            };
            _service.Edit(entity);
            TempData["Message"] = $"{entity.Id} numaralı kullanıcı güncellendi.";
            return RedirectToAction(nameof(Index), "User");
        }

        [HttpGet("{id}/{name}/{surname}")]
        public IActionResult Query(int id, string name, string surname)
        {
            var models = new List<UserViewModel>();
            var userEntitList = _service.Query(id, name, surname);
            foreach (var item in userEntitList)
            {
                models.Add(new UserViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Surname = item.Surname,
                    BirthDate = item.BirthDate,
                    Email = item.Email,
                    Gender = item.Gender,
                    GithubAccountUrl = item.GithubAccountUrl
                });
            }
            return View("Index", models);
        }

        public IActionResult NewUserPartial()
        {
            var model = new UserViewModel();
            SelectListItem[] genderList = new SelectListItem[]
            {
                new SelectListItem(){ Text="Seçiniz"},
                new SelectListItem(){Text="Kadın", Value="Female"},
                new SelectListItem(){Text="Erkek",Value="Male"}
            };
            ViewBag.GenderList = genderList;
            return PartialView(model);
        }


        [HttpPost]
        public IActionResult SaveUser(UserViewModel model)
        {
            UserEntity entity = new UserEntity
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                BirthDate = model.BirthDate,
                Email = model.Email,
                GithubAccountUrl = model.GithubAccountUrl,
                Gender = model.Gender
            };
            _service.Add(entity);

            return Ok();//Http Ok - HttpStatus 200
        }

        [HttpDelete]
        public string Delete(int id)
        {
            _service.Delete(id);
            return "Silme başarılı";
        }

    }
}