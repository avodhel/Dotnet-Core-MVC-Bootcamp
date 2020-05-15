using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Service.Dto
{
    public class AuthorBlogSummaryDto
    {
        public int BlogId { get; set; }
        public string AuthorNameSurname { get; set; }
        public string BlogTitle { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
