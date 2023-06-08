using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.Documents.Invoices;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.UI;
using WholeSaleApp.Shared.Model.CodeBook;
using WholeSaleApp.Shared.Model.Documents.Invoices;
using WholeSaleApp.Shared.Model.UI;

namespace WholeSaleApp.Shared.DTOs.Maps
{
    public static class MapperMapsExtensions
    {
        #region MenuItem
        public static MenuItemDto ToResponseDto(this MenuItem menuItem)
        {
            return new MenuItemDto()
            {
                Id = menuItem.Id,
                HierarchyId = menuItem.HierarchyId,
                Caption = menuItem.Caption,
                Icon = menuItem.Icon,
                Path = menuItem.Path
            };
        }


        #endregion

        #region CodeBook

        public static GoodDto ToResponseDto(this Good good)
        {
            return new GoodDto()
            {
                Code = good.Code,
                Id = good.Id,
                Name = good.Name,
                UnitOfMeasureId = good.UnitOfMeasureId
            };
        }
        public static PartnerDto ToResponseDto(this Partner partner)
        {
            return new PartnerDto()
            {
                Address = partner.Address,
                Id = partner.Id,
                Name = partner.Name,
                LocationId = partner.LocationId,
                Location = partner.Location.ToResponseDto(),
                ShortName = partner.ShortName
            };
        }
        public static LocationDto ToResponseDto(this Location location)
        {
            return new LocationDto()
            {
                Id = location.Id,
                ZipCode = location.ZipCode,
                Name = location.Name
            };
        }
        public static PartnerOfficeDto ToResponseDto(this PartnerOffice partnerOffice)
        {
            return new PartnerOfficeDto()
            {
                Id = partnerOffice.Id,
                Name = partnerOffice.Name,
                PartnerId = partnerOffice.PartnerId,
                Partner = partnerOffice.Partner.ToResponseDto(),
                LocationId = partnerOffice.LocationId,
                Location = partnerOffice.Location.ToResponseDto()
            };
        }
        public static UnitOfMeasureDto ToResponseDto(this UnitOfMeasure unitOfMeasure)
        {
            return new UnitOfMeasureDto()
            {
                Id = unitOfMeasure.Id,
                Name = unitOfMeasure.Name,
                ShortName = unitOfMeasure.ShortName
            };
        }
        public static VatDto ToResponseDto(this Vat vat)
        {
            return new VatDto()
            {
                Id = vat.Id,
                Name = vat.Name,
                Value = vat.Value,
                Code = vat.Code,
                StartDate = vat.StartDate,
                VatTypeId = vat.VatTypeId,
                VatType = vat.VatType.ToResponseDto()
            };
        }
        public static VatTypeDto ToResponseDto(this VatType vatType)
        {
            return new VatTypeDto()
            {
                Id = vatType.Id,
                Name = vatType.Name,
                Code = vatType.Code
            };
        }
        public static WarehouseDto ToResponseDto(this Warehouse warehouse)
        {
            return new WarehouseDto()
            {
                Id = warehouse.Id,
                Name = warehouse.Name,
                LocationId = warehouse.LocationId,
                Location = warehouse.Location.ToResponseDto(),
                Code = warehouse.Code,
                Address = warehouse.Address
            };
        }

        #endregion

        #region Documents

        public static SalesInvoiceDto ToResponseDto(this SalesInvoice invoice)
        {
            return new SalesInvoiceDto()
            {
                Id = invoice.Id
            };
        }

        #endregion
    }
}
