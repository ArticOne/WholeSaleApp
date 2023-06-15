using Json.Patch;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using WholeSaleApp.Client.Components.Modules.CrudComponentBase;
using WholeSaleApp.Client.Interfaces;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;
namespace WholeSaleApp.Client.Components.Modules.CodeBook.Partner
{
    public partial class PartnerComponent : CrudComponentBase<PartnerDto>
    {
        MudForm? partnerInputForm;


        private Lazy<Task<List<LocationDto>>> _allLocations;
        [Inject]
        public IGenericRepository<PartnerDto, PartnerAddDto> _repo { get; set; }
        [Inject]
        public IGenericRepository<LocationDto, LocationAddDto> _LocationsRepo { get; set; }

        private PartnerDto PartnerDto { get; set; } = new();

        private PartnerDto? PartnerDtoOriginal { get; set; }
        public HashSet<PartnerOfficeDto> SelectedPartnerOffices { get; set; } = new();

        private async Task Save()
        {
            partnerInputForm.Validate();

            if (!partnerInputForm.IsValid) { return; }

            if (Id != 0)
            {
                var originalAsAddDto = _mapper.Map<PartnerAddDto>(PartnerDtoOriginal);
                var updatedAddDto = _mapper.Map<PartnerAddDto>(PartnerDto);

                var rez = await _repo.PatchAsync(Id, originalAsAddDto.CreatePatch(updatedAddDto));
            }
            else
            {
                _repo.PostAsync(_mapper.Map<PartnerAddDto>(PartnerDto));
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await Load();
            _allLocations = new Lazy<Task<List<LocationDto>>>(async () => await _LocationsRepo.GetAsync());
        }

        private async Task Load()
        {
            if (Id != 0)
            {
                PartnerDto = await _repo.GetAsync(Id);
                PartnerDtoOriginal = PartnerDto.Copy();
            }
        }

        private async Task<IEnumerable<LocationDto>> SearchLocations(string value)
        {
            if (string.IsNullOrEmpty(value))
                return await _allLocations.Value;

            return (await _allLocations.Value).Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase));
        }

        private void AddPartnerOffice()
        {
            PartnerDto.PartnerOffices.Add(new PartnerOfficeDto());
        }
        private void DeletePartnerOffice(MouseEventArgs obj)
        {
            PartnerDto.PartnerOffices.RemoveAll(x => SelectedPartnerOffices.Contains(x));
        }
    }
}
