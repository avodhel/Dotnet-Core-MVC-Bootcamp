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
        private readonly BookRepository _bookRepository;
        private readonly BookAuthorRepository _bookAuthorRepository;
        public BookService(BookRepository bookRepository, BookAuthorRepository bookAuthorRepository)
        {
            _bookRepository = bookRepository;
            _bookAuthorRepository = bookAuthorRepository;
        }

        public List<Book> GetBooks()
        {
            return _bookRepository.GetAll().ToList();
        }

        public List<Book> GetBooksWithEagerLoading()
        {
            return _bookRepository.GetBooksWithEagerLoading();
        }

        public List<Book> GetBooksWithExplicitLoading()
        {
            return _bookRepository.GetBooksWithExplicitLoading();
        }

        public void Add(Book book)
        {
            _bookRepository.Insert(book);
        }

        public void Update(Book book)
        {
            _bookRepository.Update(book);
        }

        public Book GetById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public void Delete(int id)
        {
            _bookRepository.Delete(id);
        }

        public void RemoveRelationForAuthor(int bookId)
        {
            var bookAuthors = _bookAuthorRepository.GetAll();
            var relatedObjects = bookAuthors.Where(x => x.BookId == bookId);

            foreach (var bookAuthor in relatedObjects)
            {
                _bookAuthorRepository.Delete(bookAuthor);
            }
        }

        public void AddRelationForAuthor(ICollection<BookAuthor> bookAuthors)
        {
            foreach (var item in bookAuthors)
            {
                _bookAuthorRepository.Insert(item);
            }
        }
    }
}
