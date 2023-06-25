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
            CreateMap<VatType, VatTypeDto>().MaxDepth(2);
            CreateMap<VatType, VatTypeAddDto>().MaxDepth(2);
            CreateMap<VatTypeAddDto, VatType>().MaxDepth(2);
            CreateMap<VatTypeDto, VatTypeAddDto>().MaxDepth(2);
        }
    }
}
