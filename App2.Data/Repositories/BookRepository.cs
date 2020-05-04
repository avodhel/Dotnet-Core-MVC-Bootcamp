using App2.Data.Context;
using App2.Data.Entities;
using App2.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App2.Data.Repositories
{
    public class BookRepository : BaseRepository<Book>
    {
        public BookRepository(BookContext context) : base(context)
        {
        }

        /* Lazy loading direkt get denildiğinde verileri çekerken 
         * eager and explicit loading'de ihtiyacımız olduğunda çekeriz.*/

        /// <summary>
        /// arkada tek bir sql konutu çalışır
        /// </summary>
        /// <returns></returns>
        public List<Book> GetBooksWithEagerLoading()
        {
            //bana kitapları getir publisherları da dahil et
            return _context.Books
                .Include(x => x.Publisher)
                .ToList();
        }

        /// <summary>
        /// arkada birden fazla sql komutu çalışır
        /// </summary>
        /// <returns></returns>
        public List<Book> GetBooksWithExplicitLoading()
        {
            var books = GetAll();   //publisher propertyler null 
            foreach (var book in books)
            {
                _context.Entry(book)
                    .Reference(x => x.Publisher)
                    .Load();
            }

            return books.ToList();
        }
    }
}
