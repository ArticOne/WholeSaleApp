using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholeSaleApp.Shared.DTOs.DTO_Classes.UI
{
    public class MenuItemTreeViewItem
    {
        public MenuItemDto Item { get; set; } = new();
        public HashSet<MenuItemTreeViewItem> Children { get; set; }
        public bool IsExpanded { get; set; }
        public bool HasChild => Children.Any();
    }
}
