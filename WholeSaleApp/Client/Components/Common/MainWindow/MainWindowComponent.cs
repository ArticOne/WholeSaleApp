﻿using Microsoft.AspNetCore.Components;
using WholeSaleApp.Client.Components.Common.Browser;
using WholeSaleApp.Client.Helpers;
using WholeSaleApp.Client.Services;
using WholeSaleApp.Shared.DTOs.CodeBook;

namespace WholeSaleApp.Client.Components.Common.MainWindow
{
    public partial class MainWindowComponent
    {
        [Parameter]
        public string? TypeName { get; set; }



        private RenderFragment? _customRender;

        private RenderFragment? CustomRender
        {
            get
            {
                return CreateComponent();
            }
            set => _customRender = value;
        }

        private RenderFragment CreateComponent() => builder =>
        {
            var dtoType = UrlResolver.GetTypeForUrl(TypeName);
            var dtoAddType = UrlResolver.GetTypeForUrl(TypeName,true);
            builder.OpenComponent(0, typeof(BrowserComponent<,>).MakeGenericType(new Type[] { dtoType, dtoAddType }));
            builder.CloseComponent();
        };
    }
}
