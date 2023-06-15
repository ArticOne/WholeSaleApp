namespace WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook
{
    public class PartnerOfficeAddDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? PartnerId { get; set; }
        public int? LocationId { get; set; }
        public string Address { get; set; }
    }
}