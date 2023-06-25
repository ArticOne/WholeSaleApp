namespace WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.Documents.SalesInvoice
{
    public class SalesInvoiceItemAddDto
    {
        public int OrdinalNumber { get; set; }
        public int GoodId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
