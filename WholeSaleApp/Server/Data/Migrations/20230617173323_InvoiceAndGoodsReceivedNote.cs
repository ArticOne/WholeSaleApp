using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WholeSaleApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class InvoiceAndGoodsReceivedNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "VatId",
                table: "Goods");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "SalesInvoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "SalesInvoices",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getDate()");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "SalesInvoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PartnerId",
                table: "SalesInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartnerOfficeId",
                table: "SalesInvoices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GoodsReceivedNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    PartnerId = table.Column<int>(type: "int", nullable: false),
                    PartnerOfficeId = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceivedNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodsReceivedNotes_PartnerOffices_PartnerOfficeId",
                        column: x => x.PartnerOfficeId,
                        principalTable: "PartnerOffices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GoodsReceivedNotes_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoiceItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesInvoiceId = table.Column<int>(type: "int", nullable: false),
                    OrdinalNumber = table.Column<int>(type: "int", nullable: false),
                    GoodId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoiceItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceItem_Goods_GoodId",
                        column: x => x.GoodId,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceItem_SalesInvoices_SalesInvoiceId",
                        column: x => x.SalesInvoiceId,
                        principalTable: "SalesInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoodsReceivedNoteItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodsReceivedNoteId = table.Column<int>(type: "int", nullable: false),
                    OrdinalNumber = table.Column<int>(type: "int", nullable: false),
                    GoodId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceivedNoteItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodsReceivedNoteItem_GoodsReceivedNotes_GoodsReceivedNoteId",
                        column: x => x.GoodsReceivedNoteId,
                        principalTable: "GoodsReceivedNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsReceivedNoteItem_Goods_GoodId",
                        column: x => x.GoodId,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_PartnerId",
                table: "SalesInvoices",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_PartnerOfficeId",
                table: "SalesInvoices",
                column: "PartnerOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceivedNoteItem_GoodId",
                table: "GoodsReceivedNoteItem",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceivedNoteItem_GoodsReceivedNoteId",
                table: "GoodsReceivedNoteItem",
                column: "GoodsReceivedNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceivedNotes_PartnerId",
                table: "GoodsReceivedNotes",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceivedNotes_PartnerOfficeId",
                table: "GoodsReceivedNotes",
                column: "PartnerOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceItem_GoodId",
                table: "SalesInvoiceItem",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceItem_SalesInvoiceId",
                table: "SalesInvoiceItem",
                column: "SalesInvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoices_PartnerOffices_PartnerOfficeId",
                table: "SalesInvoices",
                column: "PartnerOfficeId",
                principalTable: "PartnerOffices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoices_Partners_PartnerId",
                table: "SalesInvoices",
                column: "PartnerId",
                principalTable: "Partners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoices_PartnerOffices_PartnerOfficeId",
                table: "SalesInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoices_Partners_PartnerId",
                table: "SalesInvoices");

            migrationBuilder.DropTable(
                name: "GoodsReceivedNoteItem");

            migrationBuilder.DropTable(
                name: "SalesInvoiceItem");

            migrationBuilder.DropTable(
                name: "GoodsReceivedNotes");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoices_PartnerId",
                table: "SalesInvoices");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoices_PartnerOfficeId",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "PartnerId",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "PartnerOfficeId",
                table: "SalesInvoices");

            migrationBuilder.AddColumn<int>(
                name: "VatId",
                table: "Goods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PurchaseInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInvoices", x => x.Id);
                });
        }
    }
}
