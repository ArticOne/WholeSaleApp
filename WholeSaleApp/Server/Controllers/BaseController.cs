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
    public class BaseController<TResponseDto, TRequestDto, TModel> : ControllerBase
        where TResponseDto : BaseDto where TModel : BaseModel where TRequestDto : class

    {
        protected readonly WsDbContext _db;
        protected readonly IMapperService _mapperService;



        public BaseController(IMapperService mapperService, WsDbContext db)
        {
            _db = db;
            _mapperService = mapperService;
        }

        [HttpGet("/api/[controller]")]
        public async Task<ActionResult<IEnumerable<BaseDto>>> Get()
        {
            return await _db.Set<TModel>().Select(x => _mapperService.ToDto<TModel, TResponseDto>(x)).ToListAsync();
        }

        [HttpGet("/api/[controller]/{id}")]
        public async Task<ActionResult<BaseDto>> Get(int id)
        {
            var obj = await _db.Set<TModel>().FindAsync(id);
            return _mapperService.ToDto<TModel, TResponseDto>(obj);
        }

        [HttpPost("/api/[controller]")]
        public async Task<ActionResult> Post([FromBody] TRequestDto newDto)
        {
            _db.Add<TModel>(_mapperService.ToModel<TModel, TRequestDto>(newDto));
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("/api/[controller]/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TRequestDto updatedDto)
        {
            var modelToUpdate = _mapperService.ToModel<TModel, TRequestDto>(updatedDto);
            modelToUpdate.Id = id;
            _db.Update<TModel>(modelToUpdate);
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


        /*********** TESTIRANJE - NEBITNO ***********/
        [HttpGet("/api/[controller]/CppTest")]
        public async Task<ActionResult> CppTest()
        {
            CppDLLs.CppTestDLLWrapper.fibonacci_init();
            var proba = CppDLLs.CppTestDLLWrapper.fibonacci_current();
            return Ok(proba);

        }
        /*********** TESTIRANJE - NEBITNO ***********/
    }
}
