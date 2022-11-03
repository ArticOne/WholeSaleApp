using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholeSaleApp.Shared.DTOs.CodeBook
{
    public class GoodDTO : BaseDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int UoMId { get; set; }
    }
}
