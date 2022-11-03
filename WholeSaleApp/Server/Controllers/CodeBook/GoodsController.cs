using WholeSaleApp.Server.Data;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.Model.CodeBook;

namespace WholeSaleApp.Server.Controllers.CodeBook
{
    public class GoodsController : BaseController<GoodDTO>
    {
        public GoodsController(WsDbContext db) : base(db)
        {
        }
    }
}
