using AutoMapper;
using WholeSaleApp.Shared.DTOs.Documents.Invoices;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.Documents.Invoice;
using WholeSaleApp.Shared.Model.Documents.Invoices;

namespace WholeSaleApp.Shared.DTOs.AutoMapperMaps.Documents.Invoice
{
    public class SalesInvoiceProfile : Profile
    {
        public SalesInvoiceProfile()
        {
            CreateMap<SalesInvoice, SalesInvoiceDto>();
            CreateMap<SalesInvoice, SalesInvoiceAddDto>();
            CreateMap<SalesInvoiceAddDto, SalesInvoice>();
            CreateMap<SalesInvoiceDto, SalesInvoiceAddDto>();
        }
    }
}
