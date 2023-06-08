using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WholeSaleApp.Shared.DTOs.CodeBook;

namespace WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook
{
    public class PartnerAddDto
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int LocationId { get; set; }
        public string Address { get; set; }
    }
}
