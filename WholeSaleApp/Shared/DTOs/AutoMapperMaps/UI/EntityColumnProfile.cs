using AutoMapper;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.UI;
using WholeSaleApp.Shared.DTOs.DTO_Classes.ResponseDtos.UI;
using WholeSaleApp.Shared.Model.UI;

namespace WholeSaleApp.Shared.DTOs.AutoMapperMaps.UI
{
    public class EntityColumnProfile : Profile
    {
        public EntityColumnProfile()
        {
            CreateMap<EntityColumn, EntityColumnDto>();
            CreateMap<EntityColumn, EntityColumnAddDto>();
            CreateMap<EntityColumnAddDto, EntityColumn>();
            CreateMap<EntityColumnDto, EntityColumnAddDto>();
        }
    }
}
