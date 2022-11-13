using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WholeSaleApp.Shared.DTOs;

namespace WholeSaleApp.Shared.DTOs.CodeBook
{
    public class LocationDto : BaseDto  
    {
        public string ZipCode { get; set; }
        public string Name { get; set; }
    }
}
