using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Data.Entities
{
    /// <summary>
    /// kitaplar ve yazarlar arasındaki bağlantıyı tutan class
    /// </summary>
    public class BookAuthor
    {
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
