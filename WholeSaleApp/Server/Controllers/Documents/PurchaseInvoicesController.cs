using WholeSaleApp.Server.Data;
using WholeSaleApp.Server.Interfaces;
using WholeSaleApp.Shared.DTOs.Documents.Invoices;
using WholeSaleApp.Shared.Model.Documents.Invoices;

namespace WholeSaleApp.Server.Controllers.Documents
{
    public class PurchaseInvoicesController : BaseController<PurchaseInvoiceDto, PurchaseInvoice>
    {
        public PurchaseInvoicesController(IMapperService mapperService, WsDbContext db) : base(mapperService, db)
        {
        }
    }
}
