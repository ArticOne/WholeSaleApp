using AutoMapper;
using Json.Patch;
using Microsoft.AspNetCore.Mvc;
using WholeSaleApp.Server.Data;
using WholeSaleApp.Server.Interfaces;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;
using WholeSaleApp.Shared.Model.CodeBook;

namespace WholeSaleApp.Server.Controllers.CodeBook
{
    public class PartnersController : BaseController<PartnerDto, PartnerAddDto, Partner>
    {
        public PartnersController(IMapperService mapperService, WsDbContext db, IMapper mapper) : base(mapperService, db, mapper)
        {
        }


        //[HttpPatch("/api/[controller]/{id}")]
        //public async Task<ActionResult> Patch(int id, [FromBody] JsonPatch patchDocument)
        //{
        //    var entity = await _db.Set<Partner>().FindAsync(id);

        //    var entityDto = _mapperService.ToRequestDto<Partner, PartnerAddDto>(entity);
        //    var lol = patchDocument.Apply(entityDto);
        //    var a = _mapperService.ToModel<Partner, PartnerAddDto>(lol);
        //    a.Id = id;
        //    a.PartnerOffices = 
        //    _db.Entry(entity).CurrentValues.SetValues(a);
        //    await _db.SaveChangesAsync();
        //    return Ok();
        //}


        [HttpGet("/api/[controller]/[action]/{id}")]
        public async Task<ActionResult> Avionski(int id)
        {
            var entity = await _db.Set<Partner>().FindAsync(id);
            entity.PartnerOffices.Add(new PartnerOffice
            {
                
                Address = "adresa",
                PartnerId = entity.Id,
                LocationId = 136,
                Name = "direktno kroz kontroler",
                Code = "sifra1"
            });
            var rez = await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
