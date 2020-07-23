using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App5.UI.Models.Request
{
    public class ProductUpdateRequest
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int StockCount { get; set; }
    }
}
