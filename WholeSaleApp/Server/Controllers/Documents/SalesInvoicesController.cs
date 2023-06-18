using AutoMapper;
using WholeSaleApp.Server.Data;
using WholeSaleApp.Server.Interfaces;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.ResponseDtos.Documents.Invoice;
using WholeSaleApp.Shared.Model.Documents.Invoice;

namespace WholeSaleApp.Server.Controllers.Documents
{
    public class SalesInvoicesController : BaseController<SalesInvoiceDto, VatAddDto, SalesInvoice>
    {
        public SalesInvoicesController(WsDbContext db, IMapper mapper) : base(db, mapper)
        {
        }
    }
}
