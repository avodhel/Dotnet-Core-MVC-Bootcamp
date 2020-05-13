using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace App2.Models
{
    public class BookDetailViewModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string PublisherName { get; set; }
        public List<AuthorItem> Authors { get; set; }
    }

    public class AuthorItem
    {
        public int AuthorId { get; set; }
        public string NameAndSurname { get; set; }
    }
}
