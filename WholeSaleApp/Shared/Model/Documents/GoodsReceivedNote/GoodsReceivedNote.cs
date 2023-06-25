using WholeSaleApp.Shared.Model.CodeBook;

namespace WholeSaleApp.Shared.Model.Documents.GoodsReceivedNote
{
    public class GoodsReceivedNote : BaseModel
    {
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public int PartnerId { get; set; }
        public Partner Partner { get; set; }
        public int? PartnerOfficeId { get; set; }
        public PartnerOffice PartnerOffice { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public string Note { get; set; }
        public List<GoodsReceivedNoteItem> GoodsReceivedNoteItems { get; set; }
    }
}
