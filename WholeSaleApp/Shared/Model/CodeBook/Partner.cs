using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholeSaleApp.Shared.Model.CodeBook
{
    public class Partner : BaseModel
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public string Address { get; set; }
    }
}
