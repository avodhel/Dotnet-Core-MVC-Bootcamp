using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace App5.UI.Clients
{
    public abstract class BaseClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializer _jsonSerializer;
        public BaseClient(HttpClient httpClient, JsonSerializer jsonSerializer)
        {
            _httpClient = httpClient;
            _jsonSerializer = jsonSerializer;
        }

        public async Task<TResponseType> GetResponse<TResponseType>(HttpRequestMessage requestMessage)
        {
            var response = await _httpClient.SendAsync(requestMessage);

            response.EnsureSuccessStatusCode();

            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                using (var streamReader = new StreamReader(responseStream))
                using (var jsonTextReader = new JsonTextReader(streamReader))
                {
                    return _jsonSerializer.Deserialize<TResponseType>(jsonTextReader);
                }
            }
        }

        public async Task<HttpStatusCode> SendAsync(HttpRequestMessage requestMessage)
        {
            var response = await _httpClient.SendAsync(requestMessage);

            return response.StatusCode;
        }
    }
}
