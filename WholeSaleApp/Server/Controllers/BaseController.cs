using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WholeSaleApp.Server.Data;
using WholeSaleApp.Shared.Model;

namespace WholeSaleApp.Server.Controllers
{
    [ApiController]
    public class BaseController<T> : ControllerBase where T : BaseModel
    {
        private readonly WsDbContext db; 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            return await db.Set<T>().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get(int id)
        {
            return await db.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] T newModel)
        {
            db.Add<T>(newModel);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] T updatedModel)
        {
            db.Update<T>(updatedModel);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var entityToRemove = db.Set<T>().FirstOrDefault(T => T.Id == id);
            db.Remove(entityToRemove);
        }
    }
}
