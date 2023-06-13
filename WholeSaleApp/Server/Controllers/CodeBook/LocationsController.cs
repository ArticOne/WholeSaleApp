using AutoMapper;
using WholeSaleApp.Server.Data;
using WholeSaleApp.Server.Interfaces;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;
using WholeSaleApp.Shared.Model.CodeBook;

namespace WholeSaleApp.Server.Controllers.CodeBook
{
    public class LocationsController : BaseController<LocationDto, LocationAddDto, Location>
    {
        public LocationsController(WsDbContext db, IMapper mapper) : base(db, mapper)
        {
        }
    }
}
