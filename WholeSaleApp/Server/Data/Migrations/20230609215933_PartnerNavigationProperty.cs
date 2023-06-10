using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WholeSaleApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class PartnerNavigationProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartnerOffices_Locations_LocationId",
                table: "PartnerOffices");

            migrationBuilder.DropIndex(
                name: "IX_Partners_LocationId",
                table: "Partners");

            migrationBuilder.DropIndex(
                name: "IX_PartnerOffices_LocationId",
                table: "PartnerOffices");

            migrationBuilder.DropIndex(
                name: "IX_PartnerOffices_PartnerId",
                table: "PartnerOffices");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "PartnerOffices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partners_LocationId",
                table: "Partners",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerOffices_LocationId",
                table: "PartnerOffices",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerOffices_PartnerId",
                table: "PartnerOffices",
                column: "PartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartnerOffices_Locations_LocationId",
                table: "PartnerOffices",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartnerOffices_Locations_LocationId",
                table: "PartnerOffices");

            migrationBuilder.DropIndex(
                name: "IX_Partners_LocationId",
                table: "Partners");

            migrationBuilder.DropIndex(
                name: "IX_PartnerOffices_LocationId",
                table: "PartnerOffices");

            migrationBuilder.DropIndex(
                name: "IX_PartnerOffices_PartnerId",
                table: "PartnerOffices");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "PartnerOffices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Partners_LocationId",
                table: "Partners",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartnerOffices_LocationId",
                table: "PartnerOffices",
                column: "LocationId",
                unique: true,
                filter: "[LocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerOffices_PartnerId",
                table: "PartnerOffices",
                column: "PartnerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PartnerOffices_Locations_LocationId",
                table: "PartnerOffices",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }
    }
}
