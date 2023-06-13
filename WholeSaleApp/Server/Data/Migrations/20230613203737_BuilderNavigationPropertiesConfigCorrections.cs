using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WholeSaleApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class BuilderNavigationPropertiesConfigCorrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vats_VatTypeId",
                table: "Vats");

            migrationBuilder.DropIndex(
                name: "IX_Goods_UnitOfMeasureId",
                table: "Goods");

            migrationBuilder.CreateIndex(
                name: "IX_Vats_VatTypeId",
                table: "Vats",
                column: "VatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_UnitOfMeasureId",
                table: "Goods",
                column: "UnitOfMeasureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vats_VatTypeId",
                table: "Vats");

            migrationBuilder.DropIndex(
                name: "IX_Goods_UnitOfMeasureId",
                table: "Goods");

            migrationBuilder.CreateIndex(
                name: "IX_Vats_VatTypeId",
                table: "Vats",
                column: "VatTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Goods_UnitOfMeasureId",
                table: "Goods",
                column: "UnitOfMeasureId",
                unique: true);
        }
    }
}
