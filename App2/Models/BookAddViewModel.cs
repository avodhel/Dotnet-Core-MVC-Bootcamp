using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App2.Models
{
    public class BookAddViewModel
    {
        public string Name { get; set; }
        public List<int> AuthorIds { get; set; }
        public List<SelectListItem> Authors { get; set; }
        public int PublisherId { get; set; }
        public List<SelectListItem> Publishers { get; set; }
    }
}
