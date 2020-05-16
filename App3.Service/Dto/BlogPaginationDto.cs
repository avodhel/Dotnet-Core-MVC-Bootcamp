using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Service.Dto
{
    public class BlogPaginationDto
    {
        public List<BlogDto> Blogs { get; set; }
        public int BlogPageCount { get; set; }
    }
}
