using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.UI;
using WholeSaleApp.Shared.Model.CodeBook;
using WholeSaleApp.Shared.Model.UI;

namespace WholeSaleApp.Shared.DTOs.Maps
{
    public static class MapperMapsExtensions
    {
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
    }
}
