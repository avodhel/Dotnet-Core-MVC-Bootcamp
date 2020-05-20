using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App3.Data.Entities
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public string LogType { get; set; }
        public string Message { get; set; }
        public string Url { get; set; }
    }
}
