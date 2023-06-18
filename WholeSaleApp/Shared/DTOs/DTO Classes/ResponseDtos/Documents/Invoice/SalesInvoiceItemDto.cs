using WholeSaleApp.Shared.DTOs.CodeBook;

namespace WholeSaleApp.Shared.DTOs.DTO_Classes.ResponseDtos.Documents.Invoice
{
    public class SalesInvoiceItemDto : BaseDto
    {
        public int SalesInvoiceId { get; set; }
        public SalesInvoiceDto SalesInvoice { get; set; }
        public int OrdinalNumber { get; set; }
        public int GoodId { get; set; }
        public GoodDto Good { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
