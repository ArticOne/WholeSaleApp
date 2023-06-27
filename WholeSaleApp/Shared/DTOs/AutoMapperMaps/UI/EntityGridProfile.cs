using AutoMapper;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.UI;
using WholeSaleApp.Shared.DTOs.DTO_Classes.ResponseDtos.UI;
using WholeSaleApp.Shared.Model.UI;

namespace WholeSaleApp.Shared.DTOs.AutoMapperMaps.UI
{
    public  class EntityGridProfile : Profile
    {
        public EntityGridProfile()
        {
            CreateMap<EntityGrid, EntityGridDto>();
            CreateMap<EntityGrid, EntityGridAddDto>();
            CreateMap<EntityGridAddDto, EntityGrid>();
            CreateMap<EntityGridDto, EntityGridAddDto>();
        }
    }
}
