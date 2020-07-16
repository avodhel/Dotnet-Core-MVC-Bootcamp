using System;
using System.Collections.Generic;
using System.Text;

namespace App5.Service.Model.Request
{
    public class ProductUpdateRequest
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int StockCount { get; set; }
    }
}
