

namespace WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.Documents.GoodsReceivedNote
{
    public class GoodsReceivedNoteItemAddDto
    {
        public int OrdinalNumber { get; set; }
        public int GoodId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
