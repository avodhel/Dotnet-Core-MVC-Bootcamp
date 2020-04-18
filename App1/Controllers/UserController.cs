using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App1.Entities;
using App1.Models;
using App1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App1.Controllers
{
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

        public IActionResult Add()
        {
            var model = new UserViewModel();
            SelectListItem[] genderList = new SelectListItem[]
            {
                new SelectListItem(){ Text="Seçiniz"},
                new SelectListItem(){Text="Kadın", Value="Female"},
                new SelectListItem(){Text="Erkek",Value="Male"}
            };
            model.GenderSelectList = genderList;
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
                model.GenderSelectList = genderList;
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
    }
}