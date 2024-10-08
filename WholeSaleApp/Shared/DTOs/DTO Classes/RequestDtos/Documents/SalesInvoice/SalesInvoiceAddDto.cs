﻿

namespace WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.Documents.SalesInvoice
{
    public class SalesInvoiceAddDto
    {
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public int PartnerId { get; set; }
        public int? PartnerOfficeId { get; set; }
        public int WarehouseId { get; set; }
        public string Note { get; set; }
        public List<SalesInvoiceItemAddDto> SalesInvoiceItems { get; set; }
    }
}
