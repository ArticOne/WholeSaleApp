using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Reflection;
using WholeSaleApp.Client.Interfaces;
using WholeSaleApp.Client.Services;
using WholeSaleApp.Shared.DTOs.CodeBook;

namespace WholeSaleApp.Client.Components.Modules.CodeBook.Location
{
    public partial class LocationComponent : CrudComponentBase<LocationDto>
    {
        [Parameter]
        public int Id { get; set; }

        MudForm? LocationInputForm;
        private LocationDto locationDto = new();


        [Inject]
        public IGenericRepository<LocationDto> _repo { get; set; }
        private void Save()
        {
            LocationInputForm.Validate();

            if (!LocationInputForm.IsValid) { return; }

            if (Id != 0)
            {
                _repo.PutAsync(Id, locationDto);
            }
            else
            {
                _repo.PostAsync(locationDto);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            if (Id != 0)
            {
                locationDto = await _repo.GetAsync(Id);
            }
        }
    }
}
