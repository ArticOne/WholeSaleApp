using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WholeSaleApp.Server.Data;
using WholeSaleApp.Server.Interfaces;
using WholeSaleApp.Server.Services;
using WholeSaleApp.Shared.DTOs;
using WholeSaleApp.Shared.Model;

namespace WholeSaleApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TDto, TModel> : ControllerBase where TDto : BaseDto where TModel : BaseModel
    {
        private readonly WsDbContext _db;
        private readonly IMapperService _mapperService;



        public BaseController(IMapperService mapperService, WsDbContext db)
        {
            _db = db;
            _mapperService = mapperService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TDto>>> Get()
        {
            return await _db.Set<TModel>().Select(x => _mapperService.ToDto<TModel, TDto>(x)).ToListAsync();
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<TDto>> Get(int id)
        {
            var obj = await _db.Set<TModel>().FindAsync(id);
            return _mapperService.ToDto<TModel, TDto>(obj);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TDto newDto)
        {
            _db.Add<TModel>(_mapperService.ToModel<TModel, TDto>(newDto));
            _db.SaveChanges();
            return Ok();
        }

        [HttpPut("/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TDto updatedDto)
        {
            _db.Update<TModel>(_mapperService.ToModel<TModel,TDto>(updatedDto));
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entityToRemove = await _db.Set<TModel>().FindAsync(id);
            _db.Remove(entityToRemove).Context.SaveChanges();
            return Ok();
        }
    }
}
