using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App2.Models
{
    public class AuthorIndexViewModel
    {
        [Display(Name = "Yazar No")]
        public int AuthorId { get; set; }
        [Display(Name = "Adı")]
        public string Name { get; set; }
        [Display(Name = "Soyadı")]
        public string Surname { get; set; }
    }
}
