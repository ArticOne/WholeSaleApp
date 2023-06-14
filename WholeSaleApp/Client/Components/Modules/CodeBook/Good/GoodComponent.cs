using Microsoft.AspNetCore.Components;
using MudBlazor;
using WholeSaleApp.Client.Components.Modules.CrudComponentBase;
using WholeSaleApp.Client.Interfaces;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;

namespace WholeSaleApp.Client.Components.Modules.CodeBook.Good
{
    public partial class GoodComponent : CrudComponentBase<GoodDto>
    {
        MudForm? GoodInputForm;
        private GoodDto goodDto = new();

        private Lazy<Task<List<UnitOfMeasureDto>>> _allUnitsOfMeasure;
        private Lazy<Task<List<VatTypeDto>>> _allVatTypes;

        [Inject]
        public IGenericRepository<GoodDto, GoodAddDto> _repo { get; set; }
        [Inject]
        public IGenericRepository<UnitOfMeasureDto, UnitOfMeasureAddDto> _unitsOfMeasureRepo { get; set; }
        [Inject]
        public IGenericRepository<VatTypeDto, VatTypeAddDto> _vatTypesRepository { get; set; }
        private void Save()
        {
            GoodInputForm.Validate();

            if (!GoodInputForm.IsValid) { return; }

            if (Id != 0)
            {
                _repo.PutAsync(Id, new GoodAddDto()
                {
                    Code = goodDto.Code,
                    Name = goodDto.Name,
                    UnitOfMeasureId = goodDto.UnitOfMeasure.Id,
                    VatTypeId = goodDto.VatType.Id
                });
            }
            else
            {
                _repo.PostAsync(new GoodAddDto()
                {
                    Code = goodDto.Code,
                    Name = goodDto.Name,
                    UnitOfMeasureId = goodDto.UnitOfMeasure.Id,
                    VatTypeId = goodDto.VatType.Id
                });
            }
        }

        protected override async Task OnInitializedAsync()
        {
            if (Id != 0)
            {
                goodDto = await _repo.GetAsync(Id);
            }
            _allUnitsOfMeasure = new Lazy<Task<List<UnitOfMeasureDto>>>(async () => await _unitsOfMeasureRepo.GetAsync());
            _allVatTypes = new Lazy<Task<List<VatTypeDto>>>(async () => await _vatTypesRepository.GetAsync());
        }

        private async Task<IEnumerable<VatTypeDto>> SearchVatTypes(string arg)
        {
            if (string.IsNullOrEmpty(arg))
                return await _allVatTypes.Value;

            return (await _allVatTypes.Value).Where(x => x.Name.Contains(arg, StringComparison.InvariantCultureIgnoreCase));
        }

        private async Task<IEnumerable<UnitOfMeasureDto>> SearchUnitsOfMeasure(string arg)
        {
            if (string.IsNullOrEmpty(arg))
                return await _allUnitsOfMeasure.Value;

            return (await _allUnitsOfMeasure.Value).Where(x => x.Name.Contains(arg, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
