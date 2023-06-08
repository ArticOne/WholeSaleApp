using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using WholeSaleApp.Server.Converters;

namespace WholeSaleApp.Shared.DTOs.DTO_Classes.UI
{
    public class MenuItemDto : BaseDto
    {
        [JsonConverter(typeof(SqlHierarchyIdConverter))]
        public HierarchyId HierarchyId { get; set; }
        public string Path { get; set; }
        public string Icon { get; set; }
        public string Caption { get; set; }
    }
}
