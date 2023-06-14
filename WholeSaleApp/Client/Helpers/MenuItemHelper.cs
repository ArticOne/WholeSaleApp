using Microsoft.EntityFrameworkCore;
using WholeSaleApp.Shared.DTOs.DTO_Classes.UI;

namespace WholeSaleApp.Client.Helpers
{
    public class MenuItemHelper
    {
        public static HashSet<MenuItemTreeViewItem> ConvertToTreeView(List<MenuItemDto> menuItems)
        {
            // Create a dictionary for quick lookup
            Dictionary<HierarchyId, MenuItemTreeViewItem> lookup = new Dictionary<HierarchyId, MenuItemTreeViewItem>();

            // Populate the dictionary and initialize children set
            foreach (var menuItem in menuItems)
            {
                var treeViewItem = new MenuItemTreeViewItem
                {
                    Item = menuItem,
                    Children = new HashSet<MenuItemTreeViewItem>() // Initialize children set
                };

                lookup[menuItem.HierarchyId] = treeViewItem;
            }

            // Build the tree
            foreach (var treeViewItem in lookup.Values)
            {
                // The parent id can be obtained by calling GetAncestor(1) on the HierarchyId
                var parentId = treeViewItem.Item.HierarchyId.GetAncestor(1);

                // If the parent exists in the lookup, add the current tree view item to its children
                if (lookup.ContainsKey(parentId))
                {
                    lookup[parentId].Children.Add(treeViewItem);
                }
            }

            // The root elements are those whose parent does not exist in the lookup
            HashSet<MenuItemTreeViewItem> rootItems = lookup.Values
                .Where(treeViewItem => !lookup.ContainsKey(treeViewItem.Item.HierarchyId.GetAncestor(1)))
                .ToHashSet();

            return rootItems;
        }


    }
}
