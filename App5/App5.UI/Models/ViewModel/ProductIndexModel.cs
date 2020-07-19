using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App5.UI.Models.ViewModel
{
    public class ProductIndexModel
    {
        public List<ProductViewModel> Products { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
    }
}
