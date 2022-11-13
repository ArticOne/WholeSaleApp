using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WholeSaleApp.Shared.DTOs;

namespace WholeSaleApp.Shared.DTOs.CodeBook
{
    public class VatDto : BaseDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int VatTypeId { get; set; }
        public GoodDto VatType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
