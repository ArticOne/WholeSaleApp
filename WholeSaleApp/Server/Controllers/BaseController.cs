using AutoMapper;
using Json.Patch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WholeSaleApp.Server.Data;
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
        protected readonly IMapper _mapper;


        public BaseController(WsDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet("/api/[controller]")]
        public async Task<ActionResult<IEnumerable<BaseDto>>> Get()
        {
            var rez1 = await _db.Set<TModel>().ToListAsync();
            var rez2 = rez1.Select(x => _mapper.Map<TResponseDto>(x)).ToList();
            return rez2;
            //var result = await _db.Set<TModel>().Select(x => _mapper.Map<TResponseDto>(x)).ToListAsync();
            //return result;
        }

        [HttpGet("/api/[controller]/{id}")]
        public async Task<ActionResult<BaseDto>> Get(int id)
        {
            var obj = await _db.Set<TModel>().FindAsync(id);
            return _mapper.Map<TResponseDto>(obj); ;
        }

        [HttpPost("/api/[controller]")]
        public async Task<ActionResult> Post([FromBody] TRequestDto newDto)
        {
            _db.Add(_mapper.Map<TModel>(newDto));
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("/api/[controller]/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TRequestDto updatedDto)
        {
            var modelToUpdate = _mapper.Map<TModel>(updatedDto);
            modelToUpdate.Id = id;
            _db.Update(modelToUpdate);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch("/api/[controller]/{id}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatch patchDocument)
        {
            // Load the entity from the database
            var entity = await _db.Set<TModel>().FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            // Map the entity to a DTO
            var requestDto = _mapper.Map<TRequestDto>(entity);

            var appliedPatch = patchDocument.Apply(requestDto);

            // Map the DTO back to the entity
            _mapper.Map(appliedPatch, entity);

            // Save the changes
            await _db.SaveChangesAsync();

            return NoContent();
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
