using WholeSaleApp.Server.Data;
using WholeSaleApp.Server.Interfaces;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.Model.CodeBook;

namespace WholeSaleApp.Server.Controllers.CodeBook
{
    public class WarehousesController : BaseController<WarehouseDto, Warehouse>
    {
        public WarehousesController(IMapperService mapperService, WsDbContext db) : base(mapperService, db)
        {
        }
    }
}
