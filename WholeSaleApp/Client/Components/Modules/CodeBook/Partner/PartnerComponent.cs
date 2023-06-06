using Microsoft.AspNetCore.Components;
using MudBlazor;
using WholeSaleApp.Client.Interfaces;
using WholeSaleApp.Shared.DTOs.CodeBook;

namespace WholeSaleApp.Client.Components.Modules.CodeBook.Partner
{
    public partial class PartnerComponent : CrudComponentBase<PartnerDto>
    {
        [Parameter]
        public int Id { get; set; }

        MudForm? partnerInputForm;
        private PartnerDto partnerDto = new();


        [Inject]
        public IGenericRepository<PartnerDto> _repo { get; set; }
        private void Save()
        {
            partnerInputForm.Validate();

            if (!partnerInputForm.IsValid) { return; }

            if (Id != 0)
            {
                _repo.PutAsync(Id,partnerDto);
            }
            else
            {
                _repo.PostAsync(partnerDto);
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
