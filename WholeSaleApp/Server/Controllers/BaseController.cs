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
        private readonly WsDbContext db;
        private readonly IMapperService mapperService;



        public BaseController(IMapperService mapperService, WsDbContext db)
        {
            this.db = db;
            this.mapperService = mapperService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TDto>>> Get()
        {
            return await db.Set<TModel>().Select( x => mapperService.ToDto<TModel,TDto>(x)).ToListAsync();
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<TDto>> Get(int id)
        {
            var obj = await db.Set<TModel>().FindAsync(id);
            return mapperService.ToDto<TModel, TDto>(obj);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TDto newModel)
        {
        //    db.Add<TModel>(newModel);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut("/{id}")]
        public void Put(int id, [FromBody] TDto updatedModel)
        {
          //  db.Update<TModel>(updatedModel);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var entityToRemove = db.Set<TModel>().FindAsync(id);
            db.Remove(entityToRemove);
        }
    }
}
