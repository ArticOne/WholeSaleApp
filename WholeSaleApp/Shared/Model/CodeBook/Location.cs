using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholeSaleApp.Shared.Model.CodeBook
{
    public class Location : BaseModel
    {
        public string ZipCode { get; set; }
        public string Name { get; set; }
    }
}
