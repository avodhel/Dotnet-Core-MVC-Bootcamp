using App5.UI.Clients;
using App5.UI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App5.UI.Services
{
    public class CategoryService
    {
        private readonly CategoryClient _client;
        public CategoryService(CategoryClient client)
        {
            _client = client;
        }

        public async Task<List<CategoryResponse>> GetCategories()
        {
            return await _client.GetCategories();
        }
    }
}
