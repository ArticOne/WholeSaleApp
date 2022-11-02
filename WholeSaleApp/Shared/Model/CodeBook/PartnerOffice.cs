using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholeSaleApp.Shared.Model.CodeBook
{
    public class PartnerOffice : BaseModel
    {
        public string Code { get; set; }
        public int Name { get; set; }
        public int PartnerId { get; set; }
        public Partner Partner { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public string Address { get; set; }
    }
}
