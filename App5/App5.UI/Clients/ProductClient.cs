using App5.UI.Models.Request;
using App5.UI.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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

        public async Task<HttpStatusCode> Delete(int productId)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, $"/product/delete/{productId}");
            return await SendAsync(requestMessage);
        }

        public async Task<ProductResponse> Get(int productId)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/product/get/{productId}");
            return await GetResponse<ProductResponse>(requestMessage);
        }

        public async Task Update(ProductUpdateRequest productUpdateRequest)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, "/product/update");

            var content = JsonConvert.SerializeObject(productUpdateRequest);
            requestMessage.Content = new StringContent(content, Encoding.UTF8, "application/json");

            await SendAsync(requestMessage);
        }
    }
}
