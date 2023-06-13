using AutoMapper;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;
using WholeSaleApp.Shared.Model.CodeBook;

namespace WholeSaleApp.Shared.DTOs.AutoMapperMaps.CodeBook
{
    public class VatTypeProfile : Profile
    {
        public VatTypeProfile()
        {
            CreateMap<VatType, VatTypeDto>();
            CreateMap<VatType, VatTypeAddDto>();
            CreateMap<VatTypeAddDto, VatType>();
            CreateMap<VatTypeDto, VatTypeAddDto>();
        }
    }
}
