using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using WholeSaleApp.Client.Components.Modules.CrudComponentBase;
using WholeSaleApp.Client.Interfaces;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.Documents.SalesInvoice;
using WholeSaleApp.Shared.DTOs.DTO_Classes.ResponseDtos.Documents.SalesInvoice;
using WholeSaleApp.Shared.Validation.Documents.SalesInvoice;

namespace WholeSaleApp.Client.Components.Modules.Documents.SalesInvoice
{
    public partial class SalesInvoiceComponent : CrudComponentBase<SalesInvoiceDto>

    {
        MudForm? salesInvoiceInputForm;
        private SalesInvoiceDtoValidator salesInvoiceDtoValidator = new();
        private SalesInvoiceItemDtoValidator salesInvoiceItemDtoValidator = new();

        private SalesInvoiceDto SalesInvoiceDto { get; set; } = new();
        [Inject]
        public IGenericRepository<SalesInvoiceDto, SalesInvoiceAddDto> _repo { get; set; }
        private MudDataGrid<SalesInvoiceItemDto> _dataGrid;
        private async Task Save()
        {
            salesInvoiceInputForm.Validate();

            if (!salesInvoiceInputForm.IsValid) { return; }

            if (Id != 0)
            {
                 await _repo.PutAsync(Id, _mapper.Map<SalesInvoiceAddDto>(SalesInvoiceDto));
            }
            else
            {
                await _repo.PostAsync(_mapper.Map<SalesInvoiceAddDto>(SalesInvoiceDto));
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await Load();
        }

        private async Task Load()
        {
            if (Id != 0)
            {
                SalesInvoiceDto = await _repo.GetAsync(Id);
            }
        }

        private void AddSalesInvoiceItem()
        {
            SalesInvoiceDto.SalesInvoiceItems.Add(new SalesInvoiceItemDto());
        }

        private void DeleteSelectedSalesInvoiceItems()
        {
            SalesInvoiceDto.SalesInvoiceItems.RemoveAll(x => x != null && _dataGrid.SelectedItems.Contains(x));
        }
    }
}
