using AutoMapper;
using WholeSaleApp.Server.Data;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.Documents.GoodsReceivedNote;
using WholeSaleApp.Shared.DTOs.DTO_Classes.ResponseDtos.Documents.GoodsReceivedNote;
using WholeSaleApp.Shared.Model.Documents.GoodsReceivedNote;

namespace WholeSaleApp.Server.Controllers.Documents
{
    public class GoodsReceivedNotesController : BaseController<GoodsReceivedNoteDto, GoodsReceivedNoteAddDto, GoodsReceivedNote>
    {
        public GoodsReceivedNotesController(IMapper mapper, WsDbContext db) : base(db,mapper)
        {
        }
    }
}
