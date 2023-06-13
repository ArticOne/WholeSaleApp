using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WholeSaleApp.Server.Data;
using WholeSaleApp.Server.Interfaces;
using WholeSaleApp.Server.Services;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.UI;
using WholeSaleApp.Shared.DTOs.DTO_Classes.UI;
using WholeSaleApp.Shared.Model.UI;

namespace WholeSaleApp.Server.Controllers.Documents
{
    public class MenuItemsController : BaseController<MenuItemDto, MenuItemAddDto, MenuItem>
    {
        public MenuItemsController(WsDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        [HttpGet("/api/[controller]/[action]/{level}")]
        public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetMenuItemsAtLevel(int level)
        {
            var items = await _db.MenuItems.Where(x => x.HierarchyId.GetLevel() == level)
                                                            .Select(x => _mapper.Map<MenuItemDto>(x))
                                                            .ToListAsync();
            return items;
        }

        [HttpGet("/api/[controller]/[action]/{id}")]
        public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetDescendantMenuItems(int id)
        {
            var root = await _db.MenuItems.FirstOrDefaultAsync(x => x.Id == id);
            var items = await _db.MenuItems.Where(x => x.HierarchyId.IsDescendantOf(root.HierarchyId) && x.Id != id)
                .Select(x => _mapper.Map<MenuItemDto>(x))
                .ToListAsync();
            return items;
        }
    }
}