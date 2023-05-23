using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Reflection;
using WholeSaleApp.Client.Interfaces;
using WholeSaleApp.Shared.DTOs.DTO_Classes.UI;
using static MudBlazor.Icons;

namespace WholeSaleApp.Client.Components.Common.NavBar.SubNavComponent
{
    public partial class SubNavComponent : MudComponentBase
    {
        [Parameter] public int ParentMenuItemId { get; set; }
        [Inject] private IMenuItemsRepository Repository { get; set; }
        private List<MenuItemDto> MenuItems { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            MenuItems = await Repository.GetDescendantMenuItemsAsync(ParentMenuItemId);
            await base.OnInitializedAsync();
        }
    }
}
