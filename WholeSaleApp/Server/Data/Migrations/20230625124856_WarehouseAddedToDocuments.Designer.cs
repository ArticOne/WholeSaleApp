﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WholeSaleApp.Server.Data;

#nullable disable

namespace WholeSaleApp.Server.Migrations
{
    [DbContext(typeof(WsDbContext))]
    [Migration("20230625124856_WarehouseAddedToDocuments")]
    partial class WarehouseAddedToDocuments
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WholeSaleApp.Shared.Model.CodeBook.Good", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitOfMeasureId")
                        .HasColumnType("int");

                    b.Property<int>("VatTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UnitOfMeasureId");

                    b.HasIndex("VatTypeId");

                    b.ToTable("Goods");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.CodeBook.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.CodeBook.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.CodeBook.PartnerOffice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocationId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("PartnerId");

                    b.ToTable("PartnerOffices");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.CodeBook.UnitOfMeasure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UnitsOfMeasure");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.CodeBook.Vat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VatTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VatTypeId");

                    b.ToTable("Vats");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.CodeBook.VatType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VatTypes");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.CodeBook.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.Documents.GoodsReceivedNote.GoodsReceivedNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartnerId")
                        .HasColumnType("int");

                    b.Property<int?>("PartnerOfficeId")
                        .HasColumnType("int");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PartnerId");

                    b.HasIndex("PartnerOfficeId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("GoodsReceivedNotes");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.Documents.GoodsReceivedNote.GoodsReceivedNoteItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GoodId")
                        .HasColumnType("int");

                    b.Property<int>("GoodsReceivedNoteId")
                        .HasColumnType("int");

                    b.Property<int>("OrdinalNumber")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("GoodId");

                    b.HasIndex("GoodsReceivedNoteId");

                    b.ToTable("GoodsReceivedNoteItem");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.Documents.SalesInvoice.SalesInvoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartnerId")
                        .HasColumnType("int");

                    b.Property<int?>("PartnerOfficeId")
                        .HasColumnType("int");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PartnerId");

                    b.HasIndex("PartnerOfficeId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("SalesInvoices");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.Documents.SalesInvoice.SalesInvoiceItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GoodId")
                        .HasColumnType("int");

                    b.Property<int>("OrdinalNumber")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SalesInvoiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GoodId");

                    b.HasIndex("SalesInvoiceId");

                    b.ToTable("SalesInvoiceItem");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.UI.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<HierarchyId>("HierarchyId")
                        .IsRequired()
                        .HasColumnType("hierarchyid");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.CodeBook.Good", b =>
                {
                    b.HasOne("WholeSaleApp.Shared.Model.CodeBook.UnitOfMeasure", "UnitOfMeasure")
                        .WithMany()
                        .HasForeignKey("UnitOfMeasureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WholeSaleApp.Shared.Model.CodeBook.VatType", "VatType")
                        .WithMany()
                        .HasForeignKey("VatTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UnitOfMeasure");

                    b.Navigation("VatType");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.CodeBook.Partner", b =>
                {
                    b.HasOne("WholeSaleApp.Shared.Model.CodeBook.Location", "Location")
                        .WithMany("Partners")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.CodeBook.PartnerOffice", b =>
                {
                    b.HasOne("WholeSaleApp.Shared.Model.CodeBook.Location", "Location")
                        .WithMany("PartnerOffices")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WholeSaleApp.Shared.Model.CodeBook.Partner", "Partner")
                        .WithMany("PartnerOffices")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.CodeBook.Vat", b =>
                {
                    b.HasOne("WholeSaleApp.Shared.Model.CodeBook.VatType", "VatType")
                        .WithMany("Vats")
                        .HasForeignKey("VatTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VatType");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.CodeBook.Warehouse", b =>
                {
                    b.HasOne("WholeSaleApp.Shared.Model.CodeBook.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.Documents.GoodsReceivedNote.GoodsReceivedNote", b =>
                {
                    b.HasOne("WholeSaleApp.Shared.Model.CodeBook.Partner", "Partner")
                        .WithMany()
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WholeSaleApp.Shared.Model.CodeBook.PartnerOffice", "PartnerOffice")
                        .WithMany()
                        .HasForeignKey("PartnerOfficeId");

                    b.HasOne("WholeSaleApp.Shared.Model.CodeBook.Warehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Partner");

                    b.Navigation("PartnerOffice");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.Documents.GoodsReceivedNote.GoodsReceivedNoteItem", b =>
                {
                    b.HasOne("WholeSaleApp.Shared.Model.CodeBook.Good", "Good")
                        .WithMany()
                        .HasForeignKey("GoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WholeSaleApp.Shared.Model.Documents.GoodsReceivedNote.GoodsReceivedNote", "GoodsReceivedNote")
                        .WithMany("GoodsReceivedNoteItems")
                        .HasForeignKey("GoodsReceivedNoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Good");

                    b.Navigation("GoodsReceivedNote");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.Documents.SalesInvoice.SalesInvoice", b =>
                {
                    b.HasOne("WholeSaleApp.Shared.Model.CodeBook.Partner", "Partner")
                        .WithMany()
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WholeSaleApp.Shared.Model.CodeBook.PartnerOffice", "PartnerOffice")
                        .WithMany()
                        .HasForeignKey("PartnerOfficeId");

                    b.HasOne("WholeSaleApp.Shared.Model.CodeBook.Warehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Partner");

                    b.Navigation("PartnerOffice");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.Documents.SalesInvoice.SalesInvoiceItem", b =>
                {
                    b.HasOne("WholeSaleApp.Shared.Model.CodeBook.Good", "Good")
                        .WithMany()
                        .HasForeignKey("GoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WholeSaleApp.Shared.Model.Documents.SalesInvoice.SalesInvoice", "SalesInvoice")
                        .WithMany("SalesInvoiceItems")
                        .HasForeignKey("SalesInvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Good");

                    b.Navigation("SalesInvoice");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.CodeBook.Location", b =>
                {
                    b.Navigation("PartnerOffices");

                    b.Navigation("Partners");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.CodeBook.Partner", b =>
                {
                    b.Navigation("PartnerOffices");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.CodeBook.VatType", b =>
                {
                    b.Navigation("Vats");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.Documents.GoodsReceivedNote.GoodsReceivedNote", b =>
                {
                    b.Navigation("GoodsReceivedNoteItems");
                });

            modelBuilder.Entity("WholeSaleApp.Shared.Model.Documents.SalesInvoice.SalesInvoice", b =>
                {
                    b.Navigation("SalesInvoiceItems");
                });
#pragma warning restore 612, 618
        }
    }
}
