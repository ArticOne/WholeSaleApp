using AutoMapper;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.Documents.Invoice;
using WholeSaleApp.Shared.DTOs.DTO_Classes.ResponseDtos.Documents.Invoice;
using WholeSaleApp.Shared.Model.Documents.Invoice;

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
