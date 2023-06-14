using Microsoft.AspNetCore.Components;
using MudBlazor;
using WholeSaleApp.Shared.DTOs.DTO_Classes.UI;

namespace WholeSaleApp.Client.Components.Common.NavBar.SubNavComponent
{
    public partial class SubNavComponent : MudComponentBase
    {
        [Parameter]
        public MenuItemTreeViewItem Parent
        {
            get;
            set;
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }
    }
}
