using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Types;
using WholeSaleApp.Shared.DTOs.DTO_Classes.UI;

namespace WholeSaleApp.Server.Converters
{
    public class SqlHierarchyIdConverter : JsonConverter<HierarchyId>
    {
        public override HierarchyId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string id = reader.GetString();
            //var sqlHierarchyId = (id == null || id == HierarchyId.Null.ToString()) ? SqlHierarchyId.Null : HierarchyId.Parse(id);
            return HierarchyId.Parse(id);
        }

        public override void Write(Utf8JsonWriter writer, HierarchyId value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}


