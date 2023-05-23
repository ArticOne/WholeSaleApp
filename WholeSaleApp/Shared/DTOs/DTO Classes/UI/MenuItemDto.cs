using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholeSaleApp.Shared.DTOs.DTO_Classes.UI
{
    public class MenuItemDto : BaseDto
    {
        public string Path { get; set; }
        public string Icon { get; set; }
        public string Caption { get; set; }
    }
}
