using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WholeSaleApp.Server.Data;
using WholeSaleApp.Server.Interfaces;
using WholeSaleApp.Server.Services;
using WholeSaleApp.Shared.DTOs;
using WholeSaleApp.Shared.Model;

namespace WholeSaleApp.Server.Controllers
{
    [Route("/api/[controller]")]
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

        [HttpGet("/api/[controller]")]
        public async Task<ActionResult<IEnumerable<TDto>>> Get()
        {
            return await _db.Set<TModel>().Select(x => _mapperService.ToDto<TModel, TDto>(x)).ToListAsync();
        }

        [HttpGet("/api/[controller]/{id}")]
        public async Task<ActionResult<TDto>> Get(int id)
        {
            var obj = await _db.Set<TModel>().FindAsync(id);
            return _mapperService.ToDto<TModel, TDto>(obj);
        }

        [HttpGet("/api/[controller]/avion/{proba}")]
        public async Task<ActionResult<TDto>> Get(string proba = "")
        {
            var res = await _db.Set<TModel>().Where(""" Name == "Bg2" """).ToListAsync();

            return Ok(res);
        }

        [HttpPost("/api/[controller]")]
        public async Task<ActionResult> Post([FromBody] TDto newDto)
        {
            _db.Add<TModel>(_mapperService.ToModel<TModel, TDto>(newDto));
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("/api/[controller]/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TDto updatedDto)
        {
            _db.Update<TModel>(_mapperService.ToModel<TModel,TDto>(updatedDto));
            await _db.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("/api/[controller]/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entityToRemove = await _db.Set<TModel>().FindAsync(id);
            _db.Remove(entityToRemove).Context.SaveChanges();
            return Ok();
        }
    }
}
