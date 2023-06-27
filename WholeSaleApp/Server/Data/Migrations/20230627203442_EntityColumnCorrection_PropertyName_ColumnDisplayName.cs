using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WholeSaleApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class EntityColumnCorrection_PropertyName_ColumnDisplayName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ColumnName",
                table: "EntityColumns",
                newName: "PropertyName");

            migrationBuilder.RenameIndex(
                name: "IX_EntityColumns_EntityGridId_ColumnName",
                table: "EntityColumns",
                newName: "IX_EntityColumns_EntityGridId_PropertyName");

            migrationBuilder.AddColumn<string>(
                name: "ColumnDisplayName",
                table: "EntityColumns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColumnDisplayName",
                table: "EntityColumns");

            migrationBuilder.RenameColumn(
                name: "PropertyName",
                table: "EntityColumns",
                newName: "ColumnName");

            migrationBuilder.RenameIndex(
                name: "IX_EntityColumns_EntityGridId_PropertyName",
                table: "EntityColumns",
                newName: "IX_EntityColumns_EntityGridId_ColumnName");
        }
    }
}
