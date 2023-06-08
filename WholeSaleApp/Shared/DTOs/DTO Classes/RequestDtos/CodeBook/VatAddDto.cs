namespace WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook
{
    public class VatAddDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int VatTypeId { get; set; }
        public DateTime StartDate { get; set; }
    }
}
