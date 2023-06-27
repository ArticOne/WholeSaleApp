namespace WholeSaleApp.Shared.Model.UI
{
    public class EntityColumn : BaseModel
    { 
        public int EntityGridId { get; set; }
        public EntityGrid EntityGrid { get; set; }
        public string PropertyName { get; set; }
        public string ColumnDisplayName { get; set; }
        public bool Visible { get; set; }
        public float Width { get; set; }
        public string Format { get; set; }
    }
}
