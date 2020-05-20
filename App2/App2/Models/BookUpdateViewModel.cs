using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App2.Models
{
    public class BookUpdateViewModel
    {
        [Display(Name = "Kitap No")]
        public int BookId { get; set; }
        [Display(Name = "Kitap Adı")]
        public string Name { get; set; }
        [Display(Name = "Yazarlar")]
        public List<int> AuthorIds { get; set; }
        public List<SelectListItem> Authors { get; set; }
        [Display(Name = "Yayınevi")]
        public int PublisherId { get; set; }
        public List<SelectListItem> Publishers { get; set; }
    }
}
