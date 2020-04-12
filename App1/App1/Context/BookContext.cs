using App1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App1.Context
{
    public class BookContext
    {
        public List<BookEntity> Books { get; set; }

        public BookContext()
        {
            Books = new List<BookEntity>
            {
                new BookEntity
                {
                    Id = 1,
                    Author = "Sabahattin Ali",
                    Name = "Kuyucaklı Yusuf",
                    Publisher = "YKY"
                },
                new BookEntity
                {
                    Id = 2,
                    Author = "Michael Ende",
                    Name = "Momo",
                    Publisher = "Kırmızı Kedi Yayınları"
                },
                new BookEntity
                {
                    Id = 3,
                    Author = "Author1",
                    Name = "Book1",
                    Publisher = "Publisher1"
                }
            };
        }
    }
}
