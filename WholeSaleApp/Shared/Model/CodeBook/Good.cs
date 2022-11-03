using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WholeSaleApp.Shared.Model.CodeBook
{
    public class Good : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int UnitOfMeasureId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
    }
}
