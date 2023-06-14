using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WholeSaleApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class GoodVatToVatTypeCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_Vats_VatId",
                table: "Goods");

            migrationBuilder.DropIndex(
                name: "IX_Goods_VatId",
                table: "Goods");

            migrationBuilder.AddColumn<int>(
                name: "VatTypeId",
                table: "Goods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Goods_VatTypeId",
                table: "Goods",
                column: "VatTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_VatTypes_VatTypeId",
                table: "Goods",
                column: "VatTypeId",
                principalTable: "VatTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_VatTypes_VatTypeId",
                table: "Goods");

            migrationBuilder.DropIndex(
                name: "IX_Goods_VatTypeId",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "VatTypeId",
                table: "Goods");

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
    }
}
