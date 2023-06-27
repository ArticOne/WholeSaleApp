namespace WholeSaleApp.Shared.DTOs.DTO_Classes.ResponseDtos.UI
{
    public class EntityColumnDto : BaseDto
    {
        public int EntityGridId { get; set; }
        public EntityGridDto EntityGrid { get; set; }
        public string ColumnName { get; set; }
        public bool Visible { get; set; }
        public float Width { get; set; }
        public string Type { get; set; }
    }
}
