namespace WholeSaleApp.Shared.DTOs.CodeBook
{
    public class PartnerOfficeDto : BaseDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int PartnerId { get; set; }
        public int? LocationId { get; set; }
        public LocationDto Location { get; set; }
        public string Address { get; set; }
    }
}
