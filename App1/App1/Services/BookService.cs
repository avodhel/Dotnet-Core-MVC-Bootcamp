using App1.Context;
using App1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App1.Services
{
    public class BookService
    {
        private readonly BookContext _bookContext;

        public BookService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public List<BookEntity> GetBooks()
        {
            return _bookContext.Books;
        }
    }
}
