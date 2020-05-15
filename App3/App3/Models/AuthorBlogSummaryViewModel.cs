using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App3.Models
{
    public class AuthorBlogSummaryViewModel
    {
        public int BlogId { get; set; }
        public string AuthorNameSurname { get; set; }
        public string BlogTitle { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
