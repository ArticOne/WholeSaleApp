namespace WholeSaleApp.Shared.Model.UI
{
    public class EntityGrid : BaseModel
    {
        public string Name { get; set; }
        public List<EntityColumn> EntityColumns { get; set; }
    }
}
