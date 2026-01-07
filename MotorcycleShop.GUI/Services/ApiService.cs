using MotorcycleShop.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MotorcycleShop.GUI.Services
{
    public class ApiService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _jsonOptions;

        public ApiService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7241/api/")
            };

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        // ======================
        // GET ALL
        // ======================
        public async Task<List<XeDTO>> GetAllXe()
        {
            var res = await _client.GetAsync("Xe");

            if (!res.IsSuccessStatusCode)
                return new List<XeDTO>();

            var json = await res.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<XeDTO>>(json, _jsonOptions)
                   ?? new List<XeDTO>();
        }

        // ======================
        // SEARCH
        // ======================
        public async Task<List<XeDTO>> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return await GetAllXe();

            var res = await _client.GetAsync($"Xe/search?keyword={keyword}");

            if (!res.IsSuccessStatusCode)
                return new List<XeDTO>();

            var json = await res.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<XeDTO>>(json, _jsonOptions)
                   ?? new List<XeDTO>();
        }

        // ======================
        // CREATE
        // ======================
        public async Task<bool> CreateXe(XeDTO xe)
        {
            var json = JsonSerializer.Serialize(xe);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _client.PostAsync("Xe", content);
            return res.IsSuccessStatusCode;
        }

        // ======================
        // UPDATE
        // ======================
        public async Task<bool> UpdateXe(XeDTO xe)
        {
            var json = JsonSerializer.Serialize(xe);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _client.PutAsync("Xe", content);
            return res.IsSuccessStatusCode;
        }

        // ======================
        // DELETE
        // ======================
        public async Task<bool> DeleteXe(int id)
        {
            var res = await _client.DeleteAsync($"Xe/{id}");
            return res.IsSuccessStatusCode;
        }
    }
}
