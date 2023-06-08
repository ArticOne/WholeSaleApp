using WholeSaleApp.Server.Data;
using WholeSaleApp.Server.Interfaces;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;
using WholeSaleApp.Shared.Model.CodeBook;

namespace WholeSaleApp.Server.Controllers.CodeBook
{
    public class VatTypeController : BaseController<VatTypeDto, VatTypeAddDto, VatType>
    {
        public VatTypeController(IMapperService mapperService, WsDbContext db) : base(mapperService, db)
        {
        }
    }
}
