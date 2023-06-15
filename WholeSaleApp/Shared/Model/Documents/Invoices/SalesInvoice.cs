﻿using WholeSaleApp.Shared.Model.CodeBook;

namespace WholeSaleApp.Shared.Model.Documents.Invoices
{
    public class SalesInvoice : BaseModel 
    {
        public string Code { get;  set; }
        public DateTime DateTime { get;  set; }
        public int PartnerId{ get; set; }
        public Partner Partner { get;  set; }
        public int? PartnerOfficeId { get; set; }
        public PartnerOffice PartnerOffice { get; set; }
        public string Note { get;  set; }
        public List<SalesInvoiceItem> SalesInvoiceItems { get; set; }
    }
}
