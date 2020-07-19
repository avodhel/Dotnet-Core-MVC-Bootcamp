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
    public class ProductClient : BaseClient
    {
        public ProductClient(HttpClient httpClient, JsonSerializer jsonSerializer) : base(httpClient, jsonSerializer)
        {
        }

        public async Task<List<ProductResponse>> GetProducts()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "/product/getall");
            return await GetResponse<List<ProductResponse>>(requestMessage);
        }
    }
}
