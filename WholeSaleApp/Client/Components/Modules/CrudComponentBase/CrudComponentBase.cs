﻿using Microsoft.AspNetCore.Components;

namespace WholeSaleApp.Client.Components.Modules.CrudComponentBase
{
    public partial class CrudComponentBase<T> : ComponentBase
    {
        [Parameter] public RenderFragment ChildContent { get; set; }

        private EventCallback Save()
        {
            throw new NotImplementedException();
        }
    }
}
