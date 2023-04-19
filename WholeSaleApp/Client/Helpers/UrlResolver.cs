using WholeSaleApp.Shared.DTOs;
using WholeSaleApp.Shared.DTOs.CodeBook;

namespace WholeSaleApp.Client.Helpers
{
    public class UrlResolver
    {
        public static Uri GetUrlForType<T>() where T : BaseDto
        {
            switch (typeof(T))
            {
                case Type locationDto when locationDto == typeof(LocationDto):
                    return new Uri("https://localhost:7175/api/Locations");
                case Type partnerDto when partnerDto == typeof(PartnerDto):
                    return new Uri("https://localhost:7175/api/Partners");
                default:
                    throw new Exception($"Url is not configured for type{typeof(T).Name}");
            }
        }
    }
}