using Microsoft.AspNetCore.Components;
using MudBlazor;
using WholeSaleApp.Client.Components.Modules.CrudComponentBase;
using WholeSaleApp.Client.Interfaces;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;

namespace WholeSaleApp.Client.Components.Modules.CodeBook.VatType
{
    public partial class VatTypeComponent : CrudComponentBase<VatTypeDto>
    {
        public MudForm VatTypeInputForm { get; set; }
        private VatTypeDto vatTypeDto = new();

        [Inject]
        public IGenericRepository<VatTypeDto, VatTypeAddDto> _repo { get; set; }
        private void Save()
        {
            VatTypeInputForm.Validate();

            if (!VatTypeInputForm.IsValid) { return; }

            if (Id != 0)
            {
                _repo.PutAsync(Id, new VatTypeAddDto()
                {
                    Name =  vatTypeDto.Name,
                    Code = vatTypeDto.Code,
                });
            }
            else
            {
                _repo.PostAsync(new VatTypeAddDto()
                {
                    Name = vatTypeDto.Name,
                    Code = vatTypeDto.Code,
                });
            }
        }

        protected override async Task OnInitializedAsync()
        {
            if (Id != 0)
            {
                vatTypeDto = await _repo.GetAsync(Id);
            }
        }
    }
}
