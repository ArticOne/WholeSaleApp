using WholeSaleApp.Shared.Model.CodeBook;

namespace WholeSaleApp.Shared.Model.Documents.GoodsReceivedNote
{
    public class GoodsReceivedNoteItem : BaseModel
    {
        public int GoodsReceivedNoteId { get; set; }
        public GoodsReceivedNote GoodsReceivedNote { get; set; }
        public int OrdinalNumber { get; set; }
        public int GoodId { get; set; }
        public Good Good { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
