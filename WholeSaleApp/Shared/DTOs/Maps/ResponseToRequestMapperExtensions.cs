using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;

namespace WholeSaleApp.Shared.DTOs.Maps
{
    public static class ResponseToRequestMapperExtensions
    {
        public static PartnerAddDto ToRequestDto(this PartnerDto partnerDto)
        {
            return new PartnerAddDto()
            {
                Address = partnerDto.Address,
                LocationId = partnerDto.Location.Id,
                Name = partnerDto.Name,
                ShortName = partnerDto.ShortName,
                PartnerOffices = partnerDto.PartnerOffices.Select(x => x.ToRequestDto()).ToList()
            };
        }

        public static PartnerOfficeAddDto ToRequestDto(this PartnerOfficeDto partnerOfficeDto)
        {
            return new PartnerOfficeAddDto()
            {
                Address = partnerOfficeDto.Address,
                Name = partnerOfficeDto.Name,
                PartnerId = partnerOfficeDto.PartnerId,
                Code = partnerOfficeDto.Code,
                LocationId = partnerOfficeDto.Location.Id
            };
        }
    }
}
