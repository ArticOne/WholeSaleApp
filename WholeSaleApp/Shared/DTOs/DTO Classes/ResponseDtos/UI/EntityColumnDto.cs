namespace WholeSaleApp.Shared.DTOs.DTO_Classes.ResponseDtos.UI
{
    public class EntityColumnDto : BaseDto
    {
        public int EntityGridId { get; set; }
        public EntityGridDto EntityGrid { get; set; }
        public string PropertyName { get; set; }
        public string ColumnDisplayName { get; set; }
        public bool Visible { get; set; }
        public float Width { get; set; }
        public string Format { get; set; }
    }
}
