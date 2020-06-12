using System;
using System.Collections.Generic;
using System.Text;

namespace App5.Service.Model.Response
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int StockCount { get; set; }
    }
}
