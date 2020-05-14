using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App3.Data.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
