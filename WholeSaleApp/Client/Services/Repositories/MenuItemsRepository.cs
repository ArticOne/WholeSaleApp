using System.Net.Http.Json;
using WholeSaleApp.Client.Interfaces;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.UI;
using WholeSaleApp.Shared.DTOs.DTO_Classes.UI;

namespace WholeSaleApp.Client.Services.Repositories
{
    public class MenuItemsRepository : GenericRepository<MenuItemDto, MenuItemAddDto>, IMenuItemsRepository
    {
        public MenuItemsRepository(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory, configuration)
        {
        }


        public async Task<List<MenuItemDto>> GetMenuItemsAtLevelAsync(int level)
        {
            return await _httpClient.GetFromJsonAsync<List<MenuItemDto>>($"{_url}/GetMenuItemsAtLevel/{level}");
        }

        public async Task<List<MenuItemDto>> GetDescendantMenuItemsAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<List<MenuItemDto>>($"{_url}/GetDescendantMenuItems/{id}");
        }
    }
}
