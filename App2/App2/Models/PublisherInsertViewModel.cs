using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App2.Models
{
    public class PublisherInsertViewModel
    {
        [Display(Name = "Yayın Evi")]
        public string Name { get; set; }
        [Display(Name = "Adres")]
        public string Address { get; set; }
    }
}
