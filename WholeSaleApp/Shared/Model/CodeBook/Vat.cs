﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholeSaleApp.Shared.Model.CodeBook
{
    public class Vat : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int VatTypeId { get; set; }
        public VatType VatType { get; set; }
        public DateTime StartDate { get; set; }
    }
}
