using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholeSaleApp.Shared.Model.CodeBook
{
    public class PartnerOffice : BaseModel
    {
        public int Name { get; set; }
        public int PartnerId { get; set; }
        public Partner Partner { get; set; }
    }
}
