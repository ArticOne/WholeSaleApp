using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WholeSaleApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class EntityColumnCorrection_TypeRenametoFormat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "EntityColumns",
                newName: "Format");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Format",
                table: "EntityColumns",
                newName: "Type");
        }
    }
}
