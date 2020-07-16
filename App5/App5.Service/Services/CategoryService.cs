using App5.Data.Context;
using App5.Service.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App5.Service.Services
{
    public class CategoryService
    {
        private readonly ECommerceContext _context;
        public CategoryService(ECommerceContext context)
        {
            _context = context;
        }

        public List<CategoryResponse> GetCategories()
        {
            return _context.Category.ToList().Select(x => new CategoryResponse()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
