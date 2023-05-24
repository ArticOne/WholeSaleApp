using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.UI;
using WholeSaleApp.Shared.Model.CodeBook;
using WholeSaleApp.Shared.Model.UI;

namespace WholeSaleApp.Shared.DTOs.Maps
{
    public static class ReverseMapperMapsExtensions
    {
        public static Good FromDto(this GoodDto goodDto)
        {
            return new Good()
            {
                Code = goodDto.Code,
                Id = goodDto.Id,
                Name = goodDto.Name,
                UnitOfMeasureId = goodDto.UnitOfMeasureId
            };
        }
        public static Location FromDto(this LocationDto locationDto)
        {
            return new Location()
            {
                Id = locationDto.Id,
                Name = locationDto.Name,
                ZipCode = locationDto.ZipCode
            };
        }

        public static MenuItem FromDto(this MenuItemDto menuItemDto)
        {
            return new MenuItem()
            {
                Id = menuItemDto.Id,
                HierarchyId = menuItemDto.HierarchyId,
                Caption = menuItemDto.Caption,
                Icon = menuItemDto.Icon,
                Path = menuItemDto.Path,
            };
        }
    }
}
