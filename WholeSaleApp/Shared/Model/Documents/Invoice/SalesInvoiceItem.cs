using WholeSaleApp.Shared.Model.CodeBook;

namespace WholeSaleApp.Shared.Model.Documents.Invoice
{
    public class SalesInvoiceItem : BaseModel
    {
        public int SalesInvoiceId { get; set; }
        public SalesInvoice SalesInvoice { get; set; }
        public int OrdinalNumber { get; set; }
        public int GoodId { get; set; }
        public Good Good { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
