
using AutoMapper;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;
using WholeSaleApp.Shared.Model.CodeBook;

namespace WholeSaleApp.Shared.DTOs.AutoMapperMaps
{
    public class PartnerOfficeProfile : Profile
    {
        public PartnerOfficeProfile()
        {
            CreateMap<PartnerOffice, PartnerOfficeDto>();
            CreateMap<PartnerOffice, PartnerOfficeAddDto>();
            CreateMap<PartnerOfficeAddDto, PartnerOffice>();
            CreateMap<PartnerOfficeDto, PartnerOfficeAddDto>();
        }
    }
}
