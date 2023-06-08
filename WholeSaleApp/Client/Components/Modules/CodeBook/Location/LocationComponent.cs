using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Reflection;
using WholeSaleApp.Client.Components.Modules.CrudComponentBase;
using WholeSaleApp.Client.Interfaces;
using WholeSaleApp.Client.Services;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;

namespace WholeSaleApp.Client.Components.Modules.CodeBook.Location
{
    public partial class LocationComponent : CrudComponentBase<LocationDto>
    {
        MudForm? LocationInputForm;
        private LocationDto locationDto = new();


        [Inject]
        public IGenericRepository<LocationDto, LocationAddDto> _repo { get; set; }
        private void Save()
        {
            LocationInputForm.Validate();

            if (!LocationInputForm.IsValid) { return; }

            if (Id != 0)
            {
                _repo.PutAsync(Id, new LocationAddDto()
                {
                    Name = locationDto.Name,
                    ZipCode = locationDto.ZipCode
                });
            }
            else
            {
                _repo.PostAsync(new LocationAddDto()
                {
                    Name = locationDto.Name,
                    ZipCode = locationDto.ZipCode
                });
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
