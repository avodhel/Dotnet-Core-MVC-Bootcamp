using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App2.Models;
using App2.Service;
using Microsoft.AspNetCore.Mvc;

namespace App2.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _service;
        public BookController(BookService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var model = new List<BookViewModel>();
            //databaseden dataları alacağız
            var bookEntities = _service.GetBooks();
            foreach (var entity in bookEntities)
            {
                model.Add(new BookViewModel
                {
                    Id = entity.BookId,
                    Author = entity.Author,
                    Name = entity.Name,
                    Publisher = entity.Publisher
                });
            }
            return View(model);
        }
    }
}
