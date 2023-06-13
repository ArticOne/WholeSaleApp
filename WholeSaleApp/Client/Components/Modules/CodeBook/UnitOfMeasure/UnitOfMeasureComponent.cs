using Microsoft.AspNetCore.Components;
using MudBlazor;
using WholeSaleApp.Client.Components.Modules.CrudComponentBase;
using WholeSaleApp.Client.Interfaces;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;

namespace WholeSaleApp.Client.Components.Modules.CodeBook.UnitOfMeasure
{
    public partial class UnitOfMeasureComponent : CrudComponentBase<UnitOfMeasureDto>
    {
        MudForm? UnitOfMeasureInputForm;
        private UnitOfMeasureDto unitOfMeasureDto = new();


        [Inject]
        public IGenericRepository<UnitOfMeasureDto, UnitOfMeasureAddDto> _repo { get; set; }
        private void Save()
        {
            UnitOfMeasureInputForm.Validate();

            if (!UnitOfMeasureInputForm.IsValid) { return; }

            if (Id != 0)
            {
                _repo.PutAsync(Id, new UnitOfMeasureAddDto()
                {
                    Name = unitOfMeasureDto.Name,
                    ShortName = unitOfMeasureDto.ShortName,
                });
            }
            else
            {
                _repo.PostAsync(new UnitOfMeasureAddDto()
                {
                    Name = unitOfMeasureDto.Name,
                    ShortName = unitOfMeasureDto.ShortName,
                });
            }
        }

        protected override async Task OnInitializedAsync()
        {
            if (Id != 0)
            {
                unitOfMeasureDto = await _repo.GetAsync(Id);
            }
        }
    }
}
