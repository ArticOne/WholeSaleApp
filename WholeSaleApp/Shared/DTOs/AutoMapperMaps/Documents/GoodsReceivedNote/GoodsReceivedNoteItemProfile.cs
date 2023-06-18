using AutoMapper;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.Documents.GoodsReceivedNote;
using WholeSaleApp.Shared.DTOs.DTO_Classes.ResponseDtos.Documents.GoodsReceivedNote;
using WholeSaleApp.Shared.Model.Documents.GoodsReceivedNote;

namespace WholeSaleApp.Shared.DTOs.AutoMapperMaps.Documents.GoodsReceivedNote
{
    public class GoodsReceivedNoteItemProfile : Profile
    {
        public GoodsReceivedNoteItemProfile()
        {
            CreateMap<GoodsReceivedNoteItem, GoodsReceivedNoteItemDto>();
            CreateMap<GoodsReceivedNoteItem, GoodsReceivedNoteItemAddDto>();
            CreateMap<GoodsReceivedNoteItemAddDto, GoodsReceivedNoteItem>();
            CreateMap<GoodsReceivedNoteItemDto, GoodsReceivedNoteItemDto>();
        }
    }
}
