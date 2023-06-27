using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WholeSaleApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedEntityGridAndColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntityGrids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityGrids", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityColumns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityGridId = table.Column<int>(type: "int", nullable: false),
                    ColumnName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityColumns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityColumns_EntityGrids_EntityGridId",
                        column: x => x.EntityGridId,
                        principalTable: "EntityGrids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityColumns_EntityGridId_ColumnName",
                table: "EntityColumns",
                columns: new[] { "EntityGridId", "ColumnName" });

            migrationBuilder.CreateIndex(
                name: "IX_EntityGrids_Name",
                table: "EntityGrids",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityColumns");

            migrationBuilder.DropTable(
                name: "EntityGrids");
        }
    }
}
