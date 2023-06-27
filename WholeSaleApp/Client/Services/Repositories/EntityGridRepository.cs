using System.Net.Http.Json;
using WholeSaleApp.Client.Interfaces;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.UI;
using WholeSaleApp.Shared.DTOs.DTO_Classes.ResponseDtos.UI;
using WholeSaleApp.Shared.DTOs.DTO_Classes.UI;

namespace WholeSaleApp.Client.Services.Repositories
{
    public class EntityGridRepository : GenericRepository<EntityGridDto, EntityGridAddDto>, IEntityGridRepository
    {
        public EntityGridRepository(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory, configuration)
        {
        }

        public async Task<EntityGridDto> GetByNameAsync(string name)
        {
            var proba = await _httpClient.GetFromJsonAsync<EntityGridDto>($"{_url}/GetByName/{name}");
            return proba;
        }
    }
}
