using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WholeSaleApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedVatInGood : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VatId",
                table: "Goods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Goods_VatId",
                table: "Goods",
                column: "VatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_Vats_VatId",
                table: "Goods",
                column: "VatId",
                principalTable: "Vats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_Vats_VatId",
                table: "Goods");

            migrationBuilder.DropIndex(
                name: "IX_Goods_VatId",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "VatId",
                table: "Goods");
        }
    }
}
