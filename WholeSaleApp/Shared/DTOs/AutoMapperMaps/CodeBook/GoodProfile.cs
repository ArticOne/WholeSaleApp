using AutoMapper;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;
using WholeSaleApp.Shared.Model.CodeBook;

namespace WholeSaleApp.Shared.DTOs.AutoMapperMaps.CodeBook
{
    public class GoodProfile : Profile
    {
        public GoodProfile()
        {
            CreateMap<Good, GoodDto>().MaxDepth(2);
            CreateMap<Good, GoodAddDto>().MaxDepth(2);
            CreateMap<GoodAddDto, Good>().MaxDepth(2);
            CreateMap<GoodDto, GoodAddDto>().MaxDepth(2);
        }
    }
}
