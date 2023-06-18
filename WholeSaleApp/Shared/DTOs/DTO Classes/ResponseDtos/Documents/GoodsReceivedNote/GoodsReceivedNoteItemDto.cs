using WholeSaleApp.Shared.DTOs.CodeBook;

namespace WholeSaleApp.Shared.DTOs.DTO_Classes.ResponseDtos.Documents.GoodsReceivedNote
{
    public class GoodsReceivedNoteItemDto : BaseDto
    {
        public int GoodsReceivedNoteId { get; set; }
        public GoodsReceivedNoteDto GoodsReceivedNote { get; set; }
        public int OrdinalNumber { get; set; }
        public int GoodId { get; set; }
        public GoodDto Good { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
