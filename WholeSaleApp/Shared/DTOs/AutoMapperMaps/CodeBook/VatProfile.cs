using AutoMapper;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;
using WholeSaleApp.Shared.Model.CodeBook;

namespace WholeSaleApp.Shared.DTOs.AutoMapperMaps.CodeBook
{
    public class VatProfile : Profile
    {
        public VatProfile()
        {
            CreateMap<Vat, VatDto>().MaxDepth(2);
            CreateMap<Vat, VatAddDto>().MaxDepth(2);
            CreateMap<VatAddDto, Vat>().MaxDepth(2);
            CreateMap<VatDto, VatAddDto>().MaxDepth(2);
        }
    }
}
