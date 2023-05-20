using WholeSaleApp.Shared.DTOs;
using WholeSaleApp.Shared.DTOs.CodeBook;

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
                default:
                    throw new Exception($"Url section is not configured for type{typeof(T).Name}");
            }
        }
    }
}