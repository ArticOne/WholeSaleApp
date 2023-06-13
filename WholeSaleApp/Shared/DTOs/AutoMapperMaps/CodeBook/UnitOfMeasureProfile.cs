using AutoMapper;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;
using WholeSaleApp.Shared.Model.CodeBook;

namespace WholeSaleApp.Shared.DTOs.AutoMapperMaps.CodeBook
{
    public class UnitOfMeasureProfile : Profile
    {
        public UnitOfMeasureProfile()
        {
            CreateMap<UnitOfMeasure, UnitOfMeasureDto>();
            CreateMap<UnitOfMeasure, UnitOfMeasureAddDto>();
            CreateMap<UnitOfMeasureAddDto, UnitOfMeasure>();
            CreateMap<UnitOfMeasureDto, UnitOfMeasureAddDto>();
        }
    }
}
