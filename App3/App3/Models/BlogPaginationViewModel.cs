using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App3.Models
{
    public class BlogPaginationViewModel
    {
        public List<BlogViewModel> Blogs { get; set; }
        public int BlogPageCount { get; set; }
        public int TagId { get; set; }
    }
}
