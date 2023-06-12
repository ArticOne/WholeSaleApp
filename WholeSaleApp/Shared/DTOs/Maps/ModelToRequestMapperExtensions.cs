using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;
using WholeSaleApp.Shared.Model.CodeBook;

namespace WholeSaleApp.Shared.DTOs.Maps
{
    public static class ModelToRequestMapperExtensions
    {
        public static PartnerAddDto ToRequestDto(this Partner partner)
        {
            return new PartnerAddDto()
            {
                Address = partner.Address,
                LocationId = partner.LocationId,
                Name = partner.Name,
                ShortName = partner.ShortName,
                PartnerOffices = partner.PartnerOffices.Select(x => x.ToRequestDto()).ToList()
            };
        }

        public static PartnerOfficeAddDto ToRequestDto(this PartnerOffice partnerOffice)
        {
            return new PartnerOfficeAddDto()
            {
                Address = partnerOffice.Address,
                Name = partnerOffice.Name,
                PartnerId = partnerOffice.PartnerId,
                Code = partnerOffice.Code,
                LocationId = partnerOffice.LocationId
            };
        }
    }
}
