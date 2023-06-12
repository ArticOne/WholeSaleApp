using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WholeSaleApp.Shared.DTOs;
using WholeSaleApp.Shared.Model.CodeBook;

namespace WholeSaleApp.Shared.DTOs.CodeBook
{
    public class PartnerDto : BaseDto
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public LocationDto Location { get; set; }
        public string Address { get; set; }
        public List<PartnerOfficeDto> PartnerOffices { get; set; } = new();
    }
}
