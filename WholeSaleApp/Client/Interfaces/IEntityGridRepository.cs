using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.UI;
using WholeSaleApp.Shared.DTOs.DTO_Classes.ResponseDtos.UI;
using WholeSaleApp.Shared.DTOs.DTO_Classes.UI;

namespace WholeSaleApp.Client.Interfaces
{
    public interface IEntityGridRepository : IGenericRepository<EntityGridDto, EntityGridAddDto>
    {
        Task<EntityGridDto> GetByNameAsync(string name);
    }
}
