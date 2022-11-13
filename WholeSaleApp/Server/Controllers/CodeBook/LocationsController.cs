using WholeSaleApp.Server.Data;
using WholeSaleApp.Server.Interfaces;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.Model.CodeBook;

namespace WholeSaleApp.Server.Controllers.CodeBook
{
    public class LocationsController : BaseController<LocationDto, Location>
    {
        public LocationsController(IMapperService mapperService, WsDbContext db) : base(mapperService, db)
        {
        }
    }
}
