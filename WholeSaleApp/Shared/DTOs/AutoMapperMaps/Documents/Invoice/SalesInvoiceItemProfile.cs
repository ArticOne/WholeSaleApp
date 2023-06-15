using AutoMapper;
using WholeSaleApp.Shared.DTOs.Documents.Invoices;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.Documents.Invoice;
using WholeSaleApp.Shared.Model.Documents.Invoices;

namespace WholeSaleApp.Shared.DTOs.AutoMapperMaps.Documents.Invoice
{
    public class SalesInvoiceItemProfile : Profile
    {
        public SalesInvoiceItemProfile()
        {
            CreateMap<SalesInvoiceItem, SalesInvoiceItemDto>();
            CreateMap<SalesInvoiceItem, SalesInvoiceItemAddDto>();
            CreateMap<SalesInvoiceItemAddDto, SalesInvoiceItem>();
            CreateMap<SalesInvoiceItemDto, SalesInvoiceItemAddDto>();
        }
    }
}
