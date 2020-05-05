using App2.Data.Entities;
using App2.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App2.Service.Services
{
    public class BookService
    {
        private readonly BookRepository _repository;
        public BookService(BookRepository repository)
        {
            _repository = repository;
        }

        public List<Book> GetBooks()
        {
            return _repository.GetAll().ToList();
        }

        public List<Book> GetBooksWithEagerLoading()
        {
            return _repository.GetBooksWithEagerLoading();
        }

        public List<Book> GetBooksWithExplicitLoading()
        {
            return _repository.GetBooksWithExplicitLoading();
        }
    }
}
