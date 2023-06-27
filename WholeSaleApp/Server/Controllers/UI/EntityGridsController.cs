using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.EntityFrameworkCore;
using WholeSaleApp.Server.Data;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.UI;
using WholeSaleApp.Shared.DTOs.DTO_Classes.ResponseDtos.UI;
using WholeSaleApp.Shared.DTOs.DTO_Classes.UI;
using WholeSaleApp.Shared.Model.UI;

namespace WholeSaleApp.Server.Controllers.UI
{
    public class EntityGridsController : BaseController<EntityGridDto, EntityGridAddDto, EntityGrid>
    {
        public EntityGridsController(WsDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        [HttpGet("/api/[controller]/[action]/{name}")]
        public async Task<ActionResult<EntityGridDto>> GetByName(string name)
        {
            var entityGrid = await _db.EntityGrids.FirstOrDefaultAsync(x => x.Name == name);
            if (entityGrid == null) return NotFound();
            return _mapper.Map<EntityGridDto>(entityGrid);
        }
    }
}