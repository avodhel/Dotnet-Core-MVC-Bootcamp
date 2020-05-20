using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App2.Models
{
    public class AuthorInsertViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
    }
}
