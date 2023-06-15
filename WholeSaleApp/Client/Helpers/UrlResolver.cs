using WholeSaleApp.Shared.DTOs;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.Documents.Invoices;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.Documents;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.Documents.Invoices;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.UI;
using WholeSaleApp.Shared.DTOs.DTO_Classes.UI;

namespace WholeSaleApp.Client.Helpers
{
    public class UrlResolver
    {
#warning "THIS SHOULD BE DONE BETTER"
        public static string GetUrlSectionForType<T>() where T : BaseDto
        {
            switch (typeof(T))
            {
                case Type locationDto when locationDto == typeof(LocationDto):
                    return "Locations";
                case Type partnerDto when partnerDto == typeof(PartnerDto):
                    return "Partners";
                case Type menuItemDto when menuItemDto == typeof(MenuItemDto):
                    return "MenuItems";
                case Type vatTypeDto when vatTypeDto == typeof(VatTypeDto):
                    return "VatType";
                case Type vatDto when vatDto == typeof(VatDto):
                    return "Vat";
                case Type warehouseDto when warehouseDto == typeof(WarehouseDto):
                    return "Warehouses";
                case Type goodDto when goodDto == typeof(GoodDto):
                    return "Goods";
                case Type unitOfMeasureDto when unitOfMeasureDto == typeof(UnitOfMeasureDto):
                    return "UnitsOfMeasure";
                //case Type goodsReceivedNoteDto when goodsReceivedNoteDto == typeof(GoodsReceivedNoteDto):
                //    return "GoodsReceivedNotes";
                case Type salesInvoiceDto when salesInvoiceDto == typeof(SalesInvoiceDto):
                    return "SalesInvoices";
                default:
                    throw new Exception($"Url section is not configured for type{typeof(T).Name}");
            }
        }

        public static Type GetTypeForUrl(string urlPart, bool isAddDto = false)
        {
            switch (urlPart)
            {
                case "Locations":
                    return !isAddDto ? typeof(LocationDto) : typeof(LocationAddDto);
                case "Partners":
                    return !isAddDto ? typeof(PartnerDto) : typeof(PartnerAddDto);
                case "MenuItems":
                    return !isAddDto ? typeof(MenuItemDto) : typeof(MenuItemAddDto);
                case "VatType":
                    return !isAddDto ? typeof(VatTypeDto) : typeof(VatTypeAddDto);
                case "Vat":
                    return !isAddDto ? typeof(VatDto) : typeof(VatAddDto);
                case "Warehouses":
                    return !isAddDto ? typeof(WarehouseDto) : typeof(WarehouseAddDto);
                case "Goods":
                    return !isAddDto ? typeof(GoodDto) : typeof(GoodAddDto);
                case "UnitsOfMeasure":
                    return !isAddDto ? typeof(UnitOfMeasureDto) : typeof(UnitOfMeasureAddDto);
                //case "GoodsReceivedNotes":
                //return !isAddDto ? typeof(PartnerDto) : typeof(PartnerAddDto);
                //    return typeof(GoodsReceivedNoteDto);
                case "SalesInvoices":
                    return !isAddDto ? typeof(SalesInvoiceDto) : typeof(SalesInvoiceAddDto);

                default:
                    throw new Exception($"Type is not configured for Url part: {urlPart}");
            }
        }
    }
}