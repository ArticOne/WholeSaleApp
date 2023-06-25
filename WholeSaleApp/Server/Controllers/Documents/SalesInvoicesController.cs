using AutoMapper;
using WholeSaleApp.Server.Data;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.Documents.SalesInvoice;
using WholeSaleApp.Shared.DTOs.DTO_Classes.ResponseDtos.Documents.SalesInvoice;
using WholeSaleApp.Shared.Model.Documents.SalesInvoice;

namespace WholeSaleApp.Server.Controllers.Documents
{
    public class SalesInvoicesController : BaseController<SalesInvoiceDto, SalesInvoiceAddDto, SalesInvoice>
    {
        public SalesInvoicesController(WsDbContext db, IMapper mapper) : base(db, mapper)
        {
        }
    }
}
