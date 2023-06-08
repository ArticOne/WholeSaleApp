using Microsoft.AspNetCore.Components;
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
        private PartnerDto partnerDto = new();


        [Inject]
        public IGenericRepository<PartnerDto, PartnerAddDto> _repo { get; set; }
        private void Save()
        {
            partnerInputForm.Validate();

            if (!partnerInputForm.IsValid) { return; }

            if (Id != 0)
            {
                _repo.PutAsync(Id, new PartnerAddDto()
                {
                    Address = partnerDto.Address,
                    LocationId = partnerDto.Location.Id,
                    Name = partnerDto.Name,
                    ShortName = partnerDto.ShortName,
                });
            }
            else
            {
                _repo.PostAsync(new PartnerAddDto()
                {
                    Address = partnerDto.Address,
                    LocationId = partnerDto.Location.Id,
                    Name = partnerDto.Name,
                    ShortName = partnerDto.ShortName,
                });
            }
        }

        protected override async Task OnInitializedAsync()
        {
            if (Id != 0)
            {
                partnerDto = await _repo.GetAsync(Id);
            }
        }
    }
}
