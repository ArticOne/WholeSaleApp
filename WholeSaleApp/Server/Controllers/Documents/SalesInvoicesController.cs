using AutoMapper;
using WholeSaleApp.Server.Data;
using WholeSaleApp.Server.Interfaces;
using WholeSaleApp.Shared.DTOs.Documents.Invoices;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;
using WholeSaleApp.Shared.Model.Documents.Invoices;

namespace WholeSaleApp.Server.Controllers.Documents
{
    public class SalesInvoicesController : BaseController<SalesInvoiceDto, VatAddDto, SalesInvoice>
    {
        public SalesInvoicesController(IMapperService mapperService, WsDbContext db, IMapper mapper) : base(mapperService, db, mapper)
        {
        }
    }
}
