using AutoMapper;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.Documents.Invoice;
using WholeSaleApp.Shared.DTOs.DTO_Classes.ResponseDtos.Documents.Invoice;
using WholeSaleApp.Shared.Model.Documents.Invoice;

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
