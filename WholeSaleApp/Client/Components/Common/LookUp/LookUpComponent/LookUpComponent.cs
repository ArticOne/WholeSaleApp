using Microsoft.AspNetCore.Components;
using MudBlazor;
using WholeSaleApp.Client.Components.Common.LookUp.LookUpDialog;
using WholeSaleApp.Shared.DTOs;
using WholeSaleApp.Shared.DTOs.CodeBook;

namespace WholeSaleApp.Client.Components.Common.LookUp.LookUpComponent
{
    public partial class LookUpComponent<TResponseDto,TRequestDto> : MudComponentBase where TResponseDto : BaseDto where TRequestDto : class
    {
        private async Task OpenDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.False };
            var dialog = await DialogService.ShowAsync<LookUpDialogComponent<TResponseDto, TRequestDto>>(DialogTitle, options);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                StateHasChanged();
                await SelectedItem.InvokeAsync(result.Data as TResponseDto);
            }
        }

        [Parameter]
        public EventCallback<TResponseDto> SelectedItem { get; set; }
        [Parameter]
        public string LookUpComponentTitle { get; set; }
        [Parameter]
        public string DialogTitle { get; set; }
        [Parameter] 
        public RenderFragment ChildContent { get; set; }

    }
}
