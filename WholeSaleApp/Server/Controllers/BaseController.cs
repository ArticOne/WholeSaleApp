using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WholeSaleApp.Server.Data;
using WholeSaleApp.Shared.DTOs;
using WholeSaleApp.Shared.Model;

namespace WholeSaleApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TDto, TModel> : ControllerBase where TDto : BaseDTO where TModel : BaseModel
    {
        private readonly WsDbContext db;

        public BaseController(WsDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TDto>>> Get()
        {
            return await db.Set<T>().ToListAsync();
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<TDto>> Get(int id)
        {
            return await db.Set<T>().FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TDto newModel)
        {
            db.Add<T>(newModel);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut("/{id}")]
        public void Put(int id, [FromBody] TDto updatedModel)
        {
            db.Update<T>(updatedModel);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var entityToRemove = db.Set<T>().FindAsync(id);
            db.Remove(entityToRemove);
        }
    }
}
