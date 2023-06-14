using Microsoft.AspNetCore.Components;
using MudBlazor;
using WholeSaleApp.Client.Components.Modules.CrudComponentBase;
using WholeSaleApp.Client.Interfaces;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;

namespace WholeSaleApp.Client.Components.Modules.CodeBook.Vat
{
    public partial class VatComponent : CrudComponentBase<VatDto>
    {
        MudForm? VatInputForm;
        private VatDto VatDto = new();

        private Lazy<Task<List<VatTypeDto>>> _allVatTypes;

        [Inject]
        public IGenericRepository<VatDto, VatAddDto> _repo { get; set; }
        [Inject]
        public IGenericRepository<VatTypeDto, VatTypeAddDto> _vatTypeRepo { get; set; }
        private void Save()
        {
            VatInputForm.Validate();

            if (!VatInputForm.IsValid) { return; }

            if (Id != 0)
            {
                _repo.PutAsync(Id, new VatAddDto()
                {
                    Name = VatDto.Name,
                    Code = VatDto.Code,
                    VatTypeId = VatDto.VatType.Id,
                    StartDate = (DateTime)VatDto.StartDate,
                    Value = VatDto.Value
                });
            }
            else
            {
                _repo.PostAsync(new VatAddDto()
                {
                    Name = VatDto.Name,
                    Code = VatDto.Code,
                    VatTypeId = VatDto.VatType.Id,
                    StartDate = (DateTime)VatDto.StartDate,
                    Value = VatDto.Value
                });
            }
        }

        protected override async Task OnInitializedAsync()
        {
            if (Id != 0)
            {
                VatDto = await _repo.GetAsync(Id);
            }
            _allVatTypes = new Lazy<Task<List<VatTypeDto>>>(async () => await _vatTypeRepo.GetAsync());
        }

        private async Task<IEnumerable<VatTypeDto>> SearchVatTypes(string arg)
        {
            if (string.IsNullOrEmpty(arg))
                return await _allVatTypes.Value;

            return (await _allVatTypes.Value).Where(x => x.Name.Contains(arg, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
