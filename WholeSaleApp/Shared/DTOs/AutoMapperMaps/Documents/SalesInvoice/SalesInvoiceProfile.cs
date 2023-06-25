using AutoMapper;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.Documents.SalesInvoice;
using WholeSaleApp.Shared.DTOs.DTO_Classes.ResponseDtos.Documents.SalesInvoice;

namespace WholeSaleApp.Shared.DTOs.AutoMapperMaps.Documents.SalesInvoice
{
    public class SalesInvoiceProfile : Profile
    {
        public SalesInvoiceProfile()
        {
            CreateMap<Model.Documents.SalesInvoice.SalesInvoice, SalesInvoiceDto>();
            CreateMap<Model.Documents.SalesInvoice.SalesInvoice, SalesInvoiceAddDto>();
            CreateMap<SalesInvoiceAddDto, Model.Documents.SalesInvoice.SalesInvoice>();
            CreateMap<SalesInvoiceDto, SalesInvoiceAddDto>()
                .ForMember(dest => dest.PartnerId,
                    opt => opt.MapFrom(src=> src.Partner != null ? src.Partner.Id : (int?)null));
        }
    }
}
