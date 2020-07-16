using System;
using System.Collections.Generic;
using System.Text;

namespace App5.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int StockCount { get; set; }
        public int CategoryId { get; set; }
    }
}
