﻿using Microsoft.AspNetCore.Components;
using MudBlazor;
using WholeSaleApp.Client.Components.Common.LookUp.LookUpDialog;
using WholeSaleApp.Shared.DTOs;

namespace WholeSaleApp.Client.Components.Common.LookUp.LookUpComponent
{
    public partial class LookUpComponent<TResponseDto, TRequestDto> : MudBaseInput<TResponseDto> where TResponseDto : BaseDto where TRequestDto : class
    {
        private async Task OpenDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.False };
            var parameters = new DialogParameters { { "Items", Items } };
            var dialog = await DialogService.ShowAsync<LookUpDialogComponent<TResponseDto, TRequestDto>>(DialogTitle, parameters, options);
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
        [Parameter]
        public bool Mini { get; set; } = false;
        [Parameter]
        public List<TResponseDto>? Items { get; set; }

    }
}
