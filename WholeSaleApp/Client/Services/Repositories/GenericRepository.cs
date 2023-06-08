using System.Reflection;
using System.Text;
using System.Text.Json;
using WholeSaleApp.Client.Helpers;
using WholeSaleApp.Client.Interfaces;
using WholeSaleApp.Shared.DTOs;

namespace WholeSaleApp.Client.Services.Repositories
{
    public class GenericRepository<TResponseDto, TRequestDto> : IGenericRepository<TResponseDto, TRequestDto> where TResponseDto : BaseDto where TRequestDto : class
    {
        protected IConfiguration _configuration;
        protected HttpClient _httpClient;
        protected Uri _url;

        public GenericRepository(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = httpClientFactory.CreateClient();
            _url = new Uri(_configuration["BaseApiUrl"] + UrlResolver.GetUrlSectionForType<TResponseDto>());
        }
        public async Task<List<TResponseDto>> GetAsync()
        {
            var response = await _httpClient.GetAsync(_url);
            var jsonString = await response.Content.ReadAsStringAsync();
            var deserialisedResult = JsonSerializer.Deserialize<List<TResponseDto>>(jsonString);
            return deserialisedResult == null ? new List<TResponseDto>() : deserialisedResult;
        }

        public async Task<List<TResponseDto>> GetPaginatedAsync()
        {
            var response = await _httpClient.GetAsync($"{_url}/avion/ghj");
            var jsonString = await response.Content.ReadAsStringAsync();
            var deserialisedResult = JsonSerializer.Deserialize<List<TResponseDto>>(jsonString);
            return deserialisedResult == null ? new List<TResponseDto>() : deserialisedResult;
        }

        public async Task<TResponseDto> GetAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_url}/{id}");
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponseDto>(jsonString);
        }

        public async Task<bool> PostAsync(TRequestDto dtoToPost)
        {
            var response = await _httpClient.PostAsync(_url,
                                                                        new StringContent(JsonSerializer.Serialize(dtoToPost),
                                                                        Encoding.UTF8,
                                                                        "application/json"));
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PutAsync(int id, TRequestDto dtoToPut)
        {
            var response = await _httpClient.PutAsync($"{_url}/{id}",
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
