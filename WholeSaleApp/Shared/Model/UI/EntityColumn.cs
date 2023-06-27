namespace WholeSaleApp.Shared.Model.UI
{
    public class EntityColumn : BaseModel
    { 
        public int EntityGridId { get; set; }
        public EntityGrid EntityGrid { get; set; }
        public string ColumnName { get; set; }
        public bool Visible { get; set; }
        public float Width { get; set; }
        public string Type { get; set; }
    }
}
