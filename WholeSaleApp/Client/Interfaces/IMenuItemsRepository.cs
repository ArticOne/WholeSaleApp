using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.UI;
using WholeSaleApp.Shared.DTOs.DTO_Classes.UI;

namespace WholeSaleApp.Client.Interfaces;

public interface IMenuItemsRepository : IGenericRepository<MenuItemDto, MenuItemAddDto>
{
    Task<List<MenuItemDto>> GetMenuItemsAtLevelAsync(int level);
    Task<List<MenuItemDto>> GetDescendantMenuItemsAsync(int id);
}