﻿using WholeSaleApp.Shared.DTOs.CodeBook;

namespace WholeSaleApp.Shared.DTOs.Documents.Invoices
{
    public class SalesInvoiceDto : BaseDto
    {
        public string Code { get; set; }
        public DateTime DateTime { get; set; }
        public int PartnerId { get; set; }
        public PartnerDto Partner { get; set; }
        public int? PartnerOfficeId { get; set; }
        public PartnerOfficeDto PartnerOffice { get; set; }
        public string Note { get; set; }
        public List<SalesInvoiceItemDto> SalesInvoiceItems { get; set; }
    }
}
