using WholeSaleApp.Shared.DTOs;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.UI;

namespace WholeSaleApp.Client.Helpers
{
    public class UrlResolver
    {
        public static string GetUrlSectionForType<T>() where T : BaseDto
        {
            switch (typeof(T))
            {
                case Type locationDto when locationDto == typeof(LocationDto):
                    return "Locations";
                case Type partnerDto when partnerDto == typeof(PartnerDto):
                    return "Partners";
                case Type partnerDto when partnerDto == typeof(MenuItemDto):
                    return "MenuItems";
                default:
                    throw new Exception($"Url section is not configured for type{typeof(T).Name}");
            }
        }

        public static Type GetTypeForUrl(string urlPart) 
        {
            switch (urlPart)
            {
                case "Locations":
                    return typeof(LocationDto);
                case "Partners":
                    return typeof(PartnerDto);
                case "MenuItems":
                    return typeof(MenuItemDto);
                default:
                    throw new Exception($"Type is not configured for Url part: {urlPart}");
            }
        }
    }
}