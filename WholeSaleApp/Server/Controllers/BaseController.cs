using System.Linq.Dynamic.Core;
using AutoMapper;
using Json.Patch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WholeSaleApp.Server.Data;
using WholeSaleApp.Server.Interfaces;
using WholeSaleApp.Server.Services;
using WholeSaleApp.Shared.DTOs;
using WholeSaleApp.Shared.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WholeSaleApp.Server.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class BaseController<TResponseDto, TRequestDto, TModel> : ControllerBase
        where TResponseDto : BaseDto where TModel : BaseModel where TRequestDto : class

    {
        protected readonly WsDbContext _db;
        protected readonly IMapperService _mapperService;
        private readonly IMapper _mapper;


        public BaseController(IMapperService mapperService, WsDbContext db, IMapper mapper)
        {
            _db = db;
            _mapperService = mapperService;
            _mapper = mapper;
        }

        [HttpGet("/api/[controller]")]
        public async Task<ActionResult<IEnumerable<BaseDto>>> Get()
        {
            var result = await _db.Set<TModel>().Select(x => _mapperService.ToDto<TModel, TResponseDto>(x)).ToListAsync();
            return result;
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

        //[HttpPatch("/api/[controller]/{id}")]
        //public async Task<ActionResult> Patch(int id, [FromBody] JsonPatch patchDocument)
        //{
        //    var entity = await _db.Set<TModel>().FindAsync(id);

        //    var entityDto = _mapperService.ToRequestDto<TModel, TRequestDto>(entity);
        //    var lol = patchDocument.Apply(entityDto);
        //    var a = _mapperService.ToModel<TModel, TRequestDto>(lol);
        //    var jsonPatch2 = entity.CreatePatch(a);
        //    jsonPatch2.Apply(entity);
        //    a.Id = id;
        //  //  _db.Entry(entity).CurrentValues.SetValues(a);
        //  _db.Set<TModel>().Update(a);
        //    await _db.SaveChangesAsync();
        //    return Ok();
        //}

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


           var appliedPatch =  patchDocument.Apply(requestDto);

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
