using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Data.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
