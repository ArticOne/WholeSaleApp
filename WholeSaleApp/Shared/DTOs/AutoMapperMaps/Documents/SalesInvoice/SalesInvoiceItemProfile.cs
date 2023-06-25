using AutoMapper;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.Documents.SalesInvoice;
using WholeSaleApp.Shared.DTOs.DTO_Classes.ResponseDtos.Documents.SalesInvoice;
using WholeSaleApp.Shared.Model.Documents.SalesInvoice;

namespace WholeSaleApp.Shared.DTOs.AutoMapperMaps.Documents.SalesInvoice
{
    public class SalesInvoiceItemProfile : Profile
    {
        public SalesInvoiceItemProfile()
        {
            CreateMap<SalesInvoiceItem, SalesInvoiceItemDto>();
            CreateMap<SalesInvoiceItem, SalesInvoiceItemAddDto>();
            CreateMap<SalesInvoiceItemAddDto, SalesInvoiceItem>();
            CreateMap<SalesInvoiceItemDto, SalesInvoiceItemAddDto>()
                .ForMember(dest => dest.GoodId,
                    opt => opt.MapFrom(src => src.Good != null ? src.Good.Id : (int?)null));
#warning this is bad
        }
    }
}