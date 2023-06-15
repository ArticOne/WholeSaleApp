using AutoMapper;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.Documents.GoodsReceivedNote;
using WholeSaleApp.Shared.DTOs.DTO_Classes.ResponseDtos.Documents.GoodsReceivedNotes;

namespace WholeSaleApp.Shared.DTOs.AutoMapperMaps.Documents.GoodsReceivedNote
{
    public class GoodsReceivedNoteProfile : Profile
    {
        public GoodsReceivedNoteProfile()
        {
            CreateMap<Model.Documents.GoodsReceivedNotes.GoodsReceivedNote, GoodsReceivedNoteDto>();
            CreateMap<Model.Documents.GoodsReceivedNotes.GoodsReceivedNote, GoodsReceivedNoteAddDto>();
            CreateMap<GoodsReceivedNoteAddDto, Model.Documents.GoodsReceivedNotes.GoodsReceivedNote>();
            CreateMap<GoodsReceivedNoteDto, GoodsReceivedNoteAddDto>();
        }
    }
}
