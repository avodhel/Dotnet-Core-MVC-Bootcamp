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
    public class BookController : Controller
    {
        private readonly BookService _bookService;
        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }
        /// <summary>
        /// Bütün kitapların listesini döner
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var bookEntities = _bookService.GetBooks();
            var bookViewModelList = new List<BookViewModel>();
            foreach (var entity in bookEntities)
            {
                bookViewModelList.Add(new BookViewModel
                {
                    Author = entity.Author,
                    Id = entity.Id,
                    Name = entity.Name,
                    Publisher = entity.Publisher
                });
            }
            return View(bookViewModelList);
        }

        public IActionResult Edit(int id)
        {
            var bookEntity = _bookService.Get(id);
            var model = new BookViewModel
            {
                Id = bookEntity.Id,
                Author = bookEntity.Author,
                Name = bookEntity.Name,
                Publisher = bookEntity.Publisher
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(BookViewModel model)
        {
            var bookEntity = new BookEntity
            {
                Id = model.Id,
                Name = model.Name,
                Author = model.Author,
                Publisher = model.Publisher
            };
            _bookService.Edit(bookEntity);
            var updatedEntity = _bookService.Get(model.Id);

            return View(new BookViewModel
            {
                Id = updatedEntity.Id,
                Name = updatedEntity.Name,
                Author = updatedEntity.Author,
                Publisher = updatedEntity.Publisher
            });
        }

        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return RedirectToAction(nameof(Index), "Book");
        }
    }
}