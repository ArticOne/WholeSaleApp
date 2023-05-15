using System.Reflection;
using System.Text;
using System.Text.Json;
using WholeSaleApp.Client.Helpers;
using WholeSaleApp.Client.Interfaces;
using WholeSaleApp.Shared.DTOs;

namespace WholeSaleApp.Client.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseDto
    {
        protected HttpClient _httpClient;
        private Uri _url;

        public GenericRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _url = UrlResolver.GetUrlForType<T>();
        }
        public async Task<List<T>> GetAsync()
        {
            var response = await _httpClient.GetAsync(_url);
            var jsonString = await response.Content.ReadAsStringAsync();
            var deserialisedResult = JsonSerializer.Deserialize<List<T>>(jsonString);
            return deserialisedResult == null ? new List<T>() : deserialisedResult;
        }

        public async Task<List<T>> GetPaginatedAsync()
        {
            var response = await _httpClient.GetAsync($"{_url}/avion/ghj");
            var jsonString = await response.Content.ReadAsStringAsync();
            var deserialisedResult = JsonSerializer.Deserialize<List<T>>(jsonString);
            return deserialisedResult == null ? new List<T>() : deserialisedResult;
        }

        public async Task<T> GetAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_url}/{id}");
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(jsonString);
        }

        public async Task<bool> PostAsync(T dtoToPost)
        {
            var response = await _httpClient.PostAsync(_url,
                                                                        new StringContent(JsonSerializer.Serialize(dtoToPost),
                                                                        Encoding.UTF8,
                                                                        "application/json"));
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PutAsync(T dtoToPut)
        {
            var response = await _httpClient.PutAsync(_url,
                                                                        new StringContent(JsonSerializer.Serialize(dtoToPut),
                                                                        Encoding.UTF8,
                                                                        "application/json"));
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_url}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
