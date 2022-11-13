using WholeSaleApp.Server.Data;
using WholeSaleApp.Server.Interfaces;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.Model.CodeBook;

namespace WholeSaleApp.Server.Controllers.CodeBook
{
    public class PartnersController : BaseController<PartnerDto, Partner>
    {
        public PartnersController(IMapperService mapperService,WsDbContext db) : base(mapperService,db)
        {
        }
    }
}
