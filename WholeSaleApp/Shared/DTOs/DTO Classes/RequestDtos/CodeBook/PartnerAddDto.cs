using WholeSaleApp.Shared.DTOs.CodeBook;

namespace WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook
{
    public class PartnerAddDto
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int LocationId { get; set; }
        public string Address { get; set; }
        public List<PartnerOfficeAddDto> PartnerOffices { get; set; } = new();
    }
}
