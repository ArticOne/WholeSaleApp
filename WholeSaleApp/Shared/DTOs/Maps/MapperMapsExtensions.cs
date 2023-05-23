using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.UI;
using WholeSaleApp.Shared.Model.CodeBook;
using WholeSaleApp.Shared.Model.UI;

namespace WholeSaleApp.Shared.DTOs.Maps
{
    public static class MapperMapsExtensions
    {
        public static GoodDto ToDto(this Good good)
        {
            return new GoodDto()
            {
                Code = good.Code,
                Id = good.Id,
                Name = good.Name,
                UnitOfMeasureId = good.UnitOfMeasureId
            };
        }
        public static PartnerDto ToDto(this Partner partner)
        {
            return new PartnerDto()
            {
                Address = partner.Address,
                Id = partner.Id,
                Name = partner.Name,
                LocationId = partner.LocationId,
                ShortName = partner.ShortName
            };
        }
        public static LocationDto ToDto(this Location location)
        {
            return new LocationDto()
            {
                Id = location.Id,
                ZipCode = location.ZipCode,
                Name = location.Name
            };
        }

        public static MenuItemDto ToDto(this MenuItem menuItem)
        {
            return new MenuItemDto()
            {
                Id = menuItem.Id,
                Caption = menuItem.Caption,
                Icon = menuItem.Icon,
                Path = menuItem.Path
            };
        }
    }
}
