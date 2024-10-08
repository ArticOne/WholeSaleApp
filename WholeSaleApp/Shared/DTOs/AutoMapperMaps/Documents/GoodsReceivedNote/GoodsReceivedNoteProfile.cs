﻿using AutoMapper;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.Documents.GoodsReceivedNote;
using WholeSaleApp.Shared.DTOs.DTO_Classes.ResponseDtos.Documents.GoodsReceivedNote;

namespace WholeSaleApp.Shared.DTOs.AutoMapperMaps.Documents.GoodsReceivedNote
{
    public class GoodsReceivedNoteProfile : Profile
    {
        public GoodsReceivedNoteProfile()
        {
            CreateMap<Model.Documents.GoodsReceivedNote.GoodsReceivedNote, GoodsReceivedNoteDto>();
            CreateMap<Model.Documents.GoodsReceivedNote.GoodsReceivedNote, GoodsReceivedNoteAddDto>();
            CreateMap<GoodsReceivedNoteAddDto, Model.Documents.GoodsReceivedNote.GoodsReceivedNote>();
            CreateMap<GoodsReceivedNoteDto, GoodsReceivedNoteAddDto>();
        }
    }
}
