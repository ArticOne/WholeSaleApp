using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WholeSaleApp.Server.Converters;

namespace WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.UI
{
    public class MenuItemAddDto
    {
        [JsonConverter(typeof(SqlHierarchyIdConverter))]
        public HierarchyId HierarchyId { get; set; }
        public string Path { get; set; }
        public string Icon { get; set; }
        public string Caption { get; set; }
    }
}
