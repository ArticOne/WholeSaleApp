using WholeSaleApp.Shared.Model;


namespace WholeSaleApp.Shared.DTOs.CodeBook
{
    public class GoodDto : BaseDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int UnitOfMeasureId { get; set; }
        public UnitOfMeasureDto UnitOfMeasure { get; set; }
        public int VatId { get; set; }
        public VatTypeDto VatType { get; set; }
    }


}
