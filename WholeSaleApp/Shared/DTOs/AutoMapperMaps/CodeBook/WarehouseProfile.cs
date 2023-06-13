using AutoMapper;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;
using WholeSaleApp.Shared.Model.CodeBook;

namespace WholeSaleApp.Shared.DTOs.AutoMapperMaps.CodeBook
{
    public class WarehouseProfile : Profile
    {
        public WarehouseProfile()
        {
            CreateMap<Warehouse, WarehouseDto>();
            CreateMap<Warehouse, WarehouseAddDto>();
            CreateMap<WarehouseAddDto, Warehouse>();
            CreateMap<WarehouseDto, WarehouseAddDto>();
        }
    }
}
