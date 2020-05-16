using App3.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App3.Models
{
    public class BlogIndexViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public AuthorInfoDto Author { get; set; }
        public List<TagDto> Tags { get; set; }
    }
}
