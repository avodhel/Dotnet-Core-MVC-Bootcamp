using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App2.Data.Entities;
using App2.Models;
using App2.Service.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App2.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;
        private readonly PublisherService _publisherService;
        private readonly AuthorService _authorService;
        private readonly IMapper _mapper;
        public BookController(BookService bookService, PublisherService publisherService, AuthorService authorService, IMapper mapper)
        {
            _bookService = bookService;
            _publisherService = publisherService;
            _authorService = authorService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var bookListModel = new List<BookViewModel>();
            //databaseden dataları alacağız
            var bookEntities = _bookService.GetBooks();
            //var bookEntities = _service.GetBooksWithEagerLoading();
            //var bookEntities = _service.GetBooksWithExplicitLoading();

            foreach (var entity in bookEntities)
            {
                //var bookModel = new BookViewModel
                //{
                //    Id = entity.BookId,
                //    Name = entity.Name,
                //    Publisher = entity.Publisher.Name
                //};

                var bookModel = _mapper.Map<BookViewModel>(entity);

                //foreach (var item in entity.BookAuthors)
                //{
                //    bookModel.Author += item.Author.Name + " " + item.Author.Surname + " ,";
                //}
                bookListModel.Add(bookModel);
            }

            return View(bookListModel);
        }

        public IActionResult Add()
        {
            var model = new BookAddViewModel();

            model.Publishers = new List<SelectListItem>();
            var publishers = _publisherService.GetAll();
            foreach (var publisher in publishers)
            {
                model.Publishers.Add(new SelectListItem(publisher.Name, publisher.PublisherId.ToString()));
            }

            model.Authors = new List<SelectListItem>();
            var authors = _authorService.GetAll();
            foreach (var author in authors)
            {
                model.Authors.Add(new SelectListItem(author.Name, author.AuthorId.ToString()));
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(BookAddViewModel model)
        {
            var publisher = _publisherService.GetById(model.PublisherId);
            var book = new Book()
            {
                Name = model.Name,
                Publisher = publisher
            };
            _bookService.Add(book);

            book.BookAuthors = new List<BookAuthor>();

            foreach (var authorId in model.AuthorIds)
            {
                book.BookAuthors.Add(new BookAuthor()
                {
                    BookId = book.BookId,
                    AuthorId = authorId
                });
            }
            _bookService.Update(book);

            return RedirectToAction("Index", "Book");
        }

        public IActionResult Detail(int id)
        {
            var book = _bookService.GetById(id);
            var model = _mapper.Map<BookDetailViewModel>(book);
            return View(model);
        }
    }
}
