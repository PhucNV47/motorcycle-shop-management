using MotorcycleShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace MotorcycleShop.GUI.Services
{
    public class ApiService
    {
        private readonly HttpClient _client;
        public ApiService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7241/api/")
            };
        }
        public async Task<string> GetAsync(string url)
        {
            return await _client.GetStringAsync(url);
        }
        public async Task<HttpResponseMessage> PostAsync(string url, object data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _client.PostAsync(url, content);
        }

        public async Task<HttpResponseMessage> PutAsync(string url, object data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _client.PutAsync(url, content);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            return await _client.DeleteAsync(url);
        }

        public async Task<List<XeDTO>> Search(string keyword)
        {
            var res = await _client.GetAsync($"Xe/search?keyword={keyword}");
            var json = await res.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<XeDTO>>(json);
        }



    }
}
