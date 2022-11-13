using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholeSaleApp.Shared.DTOs.CodeBook
{
    public class WarehouseDto : BaseDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public LocationDto Location { get; set; }
        public string Address { get; set; }
    }
}
