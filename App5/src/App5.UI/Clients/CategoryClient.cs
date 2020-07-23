using App5.UI.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace App5.UI.Clients
{
    public class CategoryClient : BaseClient
    {
        public CategoryClient(HttpClient httpClient, JsonSerializer jsonSerializer) : base(httpClient, jsonSerializer)
        {
        }

        public async Task<List<CategoryResponse>> GetCategories()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "/category/getall");
            return await GetResponse<List<CategoryResponse>>(requestMessage);
        }
    }
}
