using AutoMapper;
using Microsoft.AspNetCore.Components;

namespace WholeSaleApp.Client.Components.Modules.CrudComponentBase
{
    public partial class CrudComponentBase<T> : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }

        [Inject]
        protected IMapper _mapper { get; set; }

        private EventCallback Save()
        {
            throw new NotImplementedException();
        }
    }
}
