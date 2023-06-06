using Microsoft.AspNetCore.Components;
using MudBlazor;
using WholeSaleApp.Client.Components.Common.LookUp.LookUpDialog;
using WholeSaleApp.Shared.DTOs;
using WholeSaleApp.Shared.DTOs.CodeBook;

namespace WholeSaleApp.Client.Components.Common.LookUp.LookUpComponent
{
    public partial class LookUpComponent<T> : MudComponentBase where T : BaseDto
    {
        private async Task OpenDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.False };
            var dialog = await DialogService.ShowAsync<LookUpDialogComponent<T>>(DialogTitle, options);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                StateHasChanged();
                await SelectedItem.InvokeAsync(result.Data as T);
            }
        }

        [Parameter]
        public EventCallback<T> SelectedItem { get; set; }
        [Parameter]
        public string LookUpComponentTitle { get; set; }
        [Parameter]
        public string DialogTitle { get; set; }
        [Parameter] 
        public RenderFragment ChildContent { get; set; }

    }
}
