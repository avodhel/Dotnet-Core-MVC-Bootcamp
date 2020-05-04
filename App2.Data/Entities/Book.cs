using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Data.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        //public int PublisherId { get; set; }

        //virtual lazy loading için şart
        public virtual Publisher Publisher { get; set; }
    }
}
