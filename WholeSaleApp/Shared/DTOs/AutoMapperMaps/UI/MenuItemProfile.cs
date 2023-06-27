using AutoMapper;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.UI;
using WholeSaleApp.Shared.DTOs.DTO_Classes.UI;
using WholeSaleApp.Shared.Model.UI;

namespace WholeSaleApp.Shared.DTOs.AutoMapperMaps.UI
{
    public  class MenuItemProfile : Profile
    {
        public MenuItemProfile()
        {
            CreateMap<MenuItem, MenuItemDto>();
            CreateMap<MenuItem, MenuItemAddDto>();
            CreateMap<MenuItemAddDto, MenuItem>();
            CreateMap<MenuItemDto, MenuItemAddDto>();
        }
    }
}
