using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.UI;
using WholeSaleApp.Shared.DTOs.DTO_Classes.UI;
using WholeSaleApp.Shared.Model.CodeBook;
using WholeSaleApp.Shared.Model.UI;

namespace WholeSaleApp.Shared.DTOs.Maps
{
    public static class ReverseMapperMapsExtensions
    {
        #region CodeBook
        public static Good FromRequestDto(this GoodAddDto goodDto)
        {
            return new Good()
            {
                Code = goodDto.Code,
                Name = goodDto.Name,
                UnitOfMeasureId = goodDto.UnitOfMeasureId
            };
        }
        public static Location FromRequestDto(this LocationAddDto locationDto)
        {
            return new Location()
            {
                Name = locationDto.Name,
                ZipCode = locationDto.ZipCode
            };
        }
        public static Partner FromRequestDto(this PartnerAddDto partnerDto)
        {
            return new Partner()
            {
                Name = partnerDto.Name,
                Address = partnerDto.Address,
                LocationId = partnerDto.LocationId,
                ShortName = partnerDto.ShortName
            };
        }
        public static MenuItem FromRequestDto(this MenuItemAddDto menuItemDto)
        {
            return new MenuItem()
            {
                HierarchyId = menuItemDto.HierarchyId,
                Caption = menuItemDto.Caption,
                Icon = menuItemDto.Icon,
                Path = menuItemDto.Path,
            };
        }
        #endregion

        #region Documents

        #endregion


    }
}
