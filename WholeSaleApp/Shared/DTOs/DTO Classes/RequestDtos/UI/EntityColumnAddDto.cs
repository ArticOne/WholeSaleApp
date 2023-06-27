namespace WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.UI
{
    public class EntityColumnAddDto
    {
        public int EntityGridId { get; set; }
        public string PropertyName { get; set; }
        public string ColumnDisplayName { get; set; }
        public bool Visible { get; set; }
        public float Width { get; set; }
        public string Format { get; set; }
    }
}
