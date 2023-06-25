using WholeSaleApp.Shared.DTOs;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.Documents.GoodsReceivedNote;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.Documents.SalesInvoice;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.UI;
using WholeSaleApp.Shared.DTOs.DTO_Classes.ResponseDtos.Documents.GoodsReceivedNote;
using WholeSaleApp.Shared.DTOs.DTO_Classes.ResponseDtos.Documents.SalesInvoice;
using WholeSaleApp.Shared.DTOs.DTO_Classes.UI;

namespace WholeSaleApp.Client.Helpers
{
    public class UrlResolver
    {
#warning "THIS SHOULD BE DONE BETTER"
        public static string GetUrlSectionForType<T>() where T : BaseDto
        {
            return typeof(T) switch
            {
                Type locationDto when locationDto == typeof(LocationDto) => "Locations",
                Type partnerDto when partnerDto == typeof(PartnerDto) => "Partners",
                Type partnerOfficeDto when partnerOfficeDto == typeof(PartnerOfficeDto) => "PartnerOffices",
                Type menuItemDto when menuItemDto == typeof(MenuItemDto) => "MenuItems",
                Type vatTypeDto when vatTypeDto == typeof(VatTypeDto) => "VatType",
                Type vatDto when vatDto == typeof(VatDto) => "Vat",
                Type warehouseDto when warehouseDto == typeof(WarehouseDto) => "Warehouses",
                Type goodDto when goodDto == typeof(GoodDto) => "Goods",
                Type unitOfMeasureDto when unitOfMeasureDto == typeof(UnitOfMeasureDto) => "UnitsOfMeasure",
                Type goodsReceivedNoteDto when goodsReceivedNoteDto == typeof(GoodsReceivedNoteDto) => "GoodsReceivedNotes",
                Type salesInvoiceDto when salesInvoiceDto == typeof(SalesInvoiceDto) => "SalesInvoices",
                _ => throw new Exception($"Url section is not configured for type {typeof(T).Name}")
            };
        }

        public static Type GetTypeForUrl(string urlPart, bool isAddDto = false)
        {
            return urlPart switch
            {
                "Locations" => !isAddDto ? typeof(LocationDto) : typeof(LocationAddDto),
                "Partners" => !isAddDto ? typeof(PartnerDto) : typeof(PartnerAddDto),
                "PartnerOffices" => !isAddDto ? typeof(PartnerOfficeDto) : typeof(PartnerOfficeAddDto),
                "MenuItems" => !isAddDto ? typeof(MenuItemDto) : typeof(MenuItemAddDto),
                "VatType" => !isAddDto ? typeof(VatTypeDto) : typeof(VatTypeAddDto),
                "Vat" => !isAddDto ? typeof(VatDto) : typeof(VatAddDto),
                "Warehouses" => !isAddDto ? typeof(WarehouseDto) : typeof(WarehouseAddDto),
                "Goods" => !isAddDto ? typeof(GoodDto) : typeof(GoodAddDto),
                "UnitsOfMeasure" => !isAddDto ? typeof(UnitOfMeasureDto) : typeof(UnitOfMeasureAddDto),
                "GoodsReceivedNotes" => !isAddDto ? typeof(GoodsReceivedNoteDto) : typeof(GoodsReceivedNoteAddDto),
                "SalesInvoices" => !isAddDto ? typeof(SalesInvoiceDto) : typeof(SalesInvoiceAddDto),
                _ => throw new Exception($"Type is not configured for Url part: {urlPart}")
            };
        }
    }
}