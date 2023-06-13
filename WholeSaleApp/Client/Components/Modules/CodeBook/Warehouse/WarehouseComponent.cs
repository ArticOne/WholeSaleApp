using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Client.Components.Modules.CrudComponentBase;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using WholeSaleApp.Client.Interfaces;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;

namespace WholeSaleApp.Client.Components.Modules.CodeBook.Warehouse
{
    public partial class WarehouseComponent : CrudComponentBase<WarehouseDto>
    {
        MudForm? WarehouseInputForm;
        private WarehouseDto warehouseDto = new();


        [Inject]
        public IGenericRepository<WarehouseDto, WarehouseAddDto> _repo { get; set; }
        private void Save()
        {
            WarehouseInputForm.Validate();

            if (!WarehouseInputForm.IsValid) { return; }

            if (Id != 0)
            {
                _repo.PutAsync(Id, new WarehouseAddDto()
                {
                    Code = warehouseDto.Code,
                    Name = warehouseDto.Name,
                    Address = warehouseDto.Address,
                    LocationId = warehouseDto.Location.Id,
                });
            }
            else
            {
                _repo.PostAsync(new WarehouseAddDto()
                {
                    Code = warehouseDto.Code,
                    Name = warehouseDto.Name,
                    Address = warehouseDto.Address,
                    LocationId = warehouseDto.Location.Id,
                });
            }
        }

        protected override async Task OnInitializedAsync()
        {
            if (Id != 0)
            {
                warehouseDto = await _repo.GetAsync(Id);
            }
        }
    }
}
