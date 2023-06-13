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
            CreateMap<Vat, VatDto>();
            CreateMap<Vat, VatAddDto>();
            CreateMap<VatAddDto, Vat>();
            CreateMap<VatDto, VatAddDto>();
        }
    }
}
