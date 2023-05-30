using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Reflection;
using Microsoft.AspNetCore.Components.Web;
using WholeSaleApp.Client.Interfaces;
using WholeSaleApp.Shared.DTOs.DTO_Classes.UI;
using static MudBlazor.Icons;

namespace WholeSaleApp.Client.Components.Common.NavBar.SubNavComponent
{
    public partial class SubNavComponent : MudComponentBase
    {
        [Parameter] public HashSet<MenuItemTreeViewItem> MenuItems { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }
    }
}
