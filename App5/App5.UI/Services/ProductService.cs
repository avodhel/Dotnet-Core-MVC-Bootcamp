using App5.UI.Clients;
using App5.UI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace App5.UI.Services
{
    public class ProductService
    {
        private readonly ProductClient _client;
        public ProductService(ProductClient client)
        {
            _client = client;
        }

        public async Task<List<ProductResponse>> GetProducts()
        {
            try
            {
                return await _client.GetProducts();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<HttpStatusCode> Delete(int productId)
        {
            return await _client.Delete(productId);
        }
    }
}
