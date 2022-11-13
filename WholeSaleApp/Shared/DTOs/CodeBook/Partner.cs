using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WholeSaleApp.Shared.DTOs;

namespace WholeSaleApp.Shared.DTOs.CodeBook
{
    public class PartnerDto : BaseDto
    {
        public string NationalId { get; set; }
        public string TaxId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int LocationId { get; set; }
        public LocationDto Location { get; set; }
        public string Address { get; set; }
    }
}
