using AutoMapper;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;
using WholeSaleApp.Shared.Model.CodeBook;

namespace WholeSaleApp.Shared.DTOs.AutoMapperMaps.CodeBook
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Location, LocationDto>();
            CreateMap<Location, LocationAddDto>();
            CreateMap<LocationAddDto, Location>();
            CreateMap<LocationDto, LocationAddDto>();
        }
    }
}
