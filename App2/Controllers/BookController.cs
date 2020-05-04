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
            var bookListModel = new List<BookViewModel>();
            //databaseden dataları alacağız
            var bookEntities = _service.GetBooks();
            //var bookEntities = _service.GetBooksWithEagerLoading();
            //var bookEntities = _service.GetBooksWithExplicitLoading();

            foreach (var entity in bookEntities)
            {
                var bookModel = new BookViewModel
                {
                    Id = entity.BookId,
                    Name = entity.Name,
                    Publisher = entity.Publisher.Name
                };

                foreach (var item in entity.BookAuthors)
                {
                    bookModel.Author += item.Author.Name + " " + item.Author.Surname + " ,";
                }
                bookListModel.Add(bookModel);
            }

            return View(bookListModel);
        }
    }
}
