
using WholeSaleApp.Server.Interfaces;
using WholeSaleApp.Shared.DTOs;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.Documents.Invoices;
using WholeSaleApp.Shared.Model;
using WholeSaleApp.Shared.Model.CodeBook;
using WholeSaleApp.Shared.Model.Documents.Invoices;

namespace WholeSaleApp.Server.Services
{
    public class MapperService : IMapperService
    {
        public TDto ToDto<TModel, TDto>(TModel model) where TModel : BaseModel where TDto : BaseDto
        {
            BaseDto returnDto = GetDto(model);
            if (model is Good)
            {
                var input = model as Good;
                returnDto = new GoodDto()
                {
                    Code = input.Code,
                    Id = input.Id,
                    Name = input.Name,
                    UoMId = input.UnitOfMeasureId
                };
            }
            return (TDto)returnDto;
        }


        public TModel ToModel<TModel, TDto>(TDto dto) where TModel : BaseModel where TDto : BaseDto
        {
            throw new NotImplementedException();
        }

        private static dynamic GetDto<TModel>(TModel model) where TModel : BaseModel
        {
            return model switch
            {
                Good => new GoodDto(),
                Location => new LocationDto(),
                Partner => new PartnerDto(),
                PartnerOffice => new PartnerOfficeDto(),
                UnitOfMeasure => new UnitOfMeasureDto(),
                Vat => new VatDto(),
                VatType => new VatTypeDto(),
                Warehouse => new WarehouseDto(),
                PurchaseInvoice => new PurchaseInvoiceDto(),
                PurchaseInvoiceItem => new PurchaseInvoiceDto(),
                SalesInvoice => new SalesInvoiceDto(),
                SalesInvoiceitem => new SalesInvoiceitemDto(),
                _ => throw new NotImplementedException()
            };
        }
        //private static dynamic GetDtoOrModel<TModel>(TModel model, bool blnDto) where TModel : BaseModel
        //{
        //    return model switch
        //    {
        //        Good => blnDto ? new GoodDto() : new Good(),
        //        Location => blnDto ? new LocationDto() : new Location(),
        //        Partner => blnDto ? new PartnerDto() : new Partner(),
        //        PartnerOffice => blnDto ? new PartnerOfficeDto() : new PartnerOffice(),
        //        UnitOfMeasure => blnDto ? new UnitOfMeasureDto() : new UnitOfMeasure(),
        //        Vat => blnDto ? new VatDto() : new Vat(),
        //        VatType => blnDto ? new VatTypeDto() : new VatType(),
        //        Warehouse => blnDto ? new WarehouseDto() : new Warehouse(),
        //        PurchaseInvoice => blnDto ? new PurchaseInvoiceDto() : new PurchaseInvoice(),
        //        PurchaseInvoiceItem => blnDto ? new PurchaseInvoiceDto() : new PurchaseInvoice(),
        //        SalesInvoice => blnDto ? new SalesInvoiceDto() : new SalesInvoice(),
        //        SalesInvoiceitem => blnDto ? new SalesInvoiceitemDto() : new SalesInvoiceitem(),
        //        _ => throw new NotImplementedException()
        //    };
        //}
    }
}
