using Microsoft.EntityFrameworkCore;

namespace WholeSaleApp.Shared.Model.UI
{
    public class MenuItem : BaseModel
    {
        public HierarchyId HierarchyId { get; set; }
        public string Path { get; set; }
        public string Icon { get; set; }
        public string Caption { get; set; }
    }
}
