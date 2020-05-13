using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App2.Models
{
    public class PublisherDetailViewModel
    {
        [Display(Name = "Yayınevi No")]
        public int PublisherId { get; set; }
        [Display(Name = "Yayınevi Adı")]
        public string Name { get; set; }
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [Display(Name = "Yayınevine ait kitaplar")]
        public List<string> Books { get; set; }
    }
}
