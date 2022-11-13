using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.Model.CodeBook;

namespace WholeSaleApp.Shared.DTOs.Maps
{
    public static class ReverseMapperMapsExtensions
    {
        public static Good FromDto(this GoodDto good)
        {
            return new Good()
            {
                Code = good.Code,
                Id = good.Id,
                Name = good.Name,
                UnitOfMeasureId = good.UnitOfMeasureId
            };
        }
    }
}
