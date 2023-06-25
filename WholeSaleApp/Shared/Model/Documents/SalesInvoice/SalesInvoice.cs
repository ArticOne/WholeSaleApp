using WholeSaleApp.Shared.Model.CodeBook;

namespace WholeSaleApp.Shared.Model.Documents.SalesInvoice
{
    public class SalesInvoice : BaseModel 
    {
        public string Code { get;  set; }
        public DateTime Date { get;  set; }
        public int PartnerId{ get; set; }
        public Partner Partner { get;  set; }
        public int? PartnerOfficeId { get; set; }
        public PartnerOffice PartnerOffice { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public string Note { get;  set; }
        public List<SalesInvoiceItem> SalesInvoiceItems { get; set; }
    }
}
