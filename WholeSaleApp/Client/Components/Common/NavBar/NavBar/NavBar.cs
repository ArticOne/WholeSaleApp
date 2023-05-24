using Microsoft.AspNetCore.Components;
using WholeSaleApp.Client.Interfaces;
using WholeSaleApp.Shared.DTOs.DTO_Classes.UI;

namespace WholeSaleApp.Client.Components.Common.NavBar.NavBar
{
    public partial class NavBar
    {
        bool open = true;
        [Inject] private IMenuItemsRepository Repository { get; set; }
        private List<MenuItemDto> MenuItems { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            MenuItems = await Repository.GetAsync();
            await base.OnInitializedAsync();
        }

    }
}
