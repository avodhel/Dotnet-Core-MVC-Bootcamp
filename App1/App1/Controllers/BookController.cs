using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}