﻿using Microsoft.EntityFrameworkCore;
using WholeSaleApp.Shared.Model.CodeBook;
using WholeSaleApp.Shared.Model.Documents.GoodsReceivedNote;
using WholeSaleApp.Shared.Model.Documents.SalesInvoice;
using WholeSaleApp.Shared.Model.UI;

namespace WholeSaleApp.Server.Data
{
    public class WsDbContext : DbContext
    {
        private readonly IConfiguration _config;

        public DbSet<Good> Goods { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<PartnerOffice> PartnerOffices { get; set; }
        public DbSet<UnitOfMeasure> UnitsOfMeasure { get; set; }
        public DbSet<VatType> VatTypes { get; set; }
        public DbSet<Vat> Vats { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<GoodsReceivedNote> GoodsReceivedNotes { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<EntityGrid> EntityGrids { get; set; }
        public DbSet<EntityColumn> EntityColumns { get; set; }

        public WsDbContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder
           .UseSqlServer(_config.GetConnectionString("Db"), conf =>
           {
               conf.UseHierarchyId();
           });

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Good>()
                .HasOne<UnitOfMeasure>(g => g.UnitOfMeasure)
                .WithMany()
                .IsRequired();

            modelBuilder.Entity<Partner>()
                .HasOne<Location>(p => p.Location)
                .WithMany(l => l.Partners)
                .IsRequired();

            modelBuilder.Entity<PartnerOffice>()
                .HasOne<Location>(po => po.Location)
                .WithMany(l => l.PartnerOffices)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PartnerOffice>()
                .HasOne<Partner>(po => po.Partner)
                .WithMany(x => x.PartnerOffices)
                .IsRequired();

            modelBuilder.Entity<Vat>()
                .HasOne<VatType>(v => v.VatType)
                .WithMany(x => x.Vats)
                .IsRequired();

            modelBuilder.Entity<Good>()
                .HasOne<VatType>(g => g.VatType)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SalesInvoice>()
                .HasMany(x => x.SalesInvoiceItems)
                .WithOne(x => x.SalesInvoice)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GoodsReceivedNote>()
                .HasMany(x => x.GoodsReceivedNoteItems)
                .WithOne(x => x.GoodsReceivedNote)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SalesInvoice>()
                .HasOne(x => x.Warehouse)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GoodsReceivedNote>()
                .HasOne(x => x.Warehouse)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SalesInvoice>()
                .Property(e => e.Date)
                .HasDefaultValueSql("getDate()");

            modelBuilder.Entity<GoodsReceivedNote>()
                .Property(e => e.Date)
                .HasDefaultValueSql("getDate()");

            modelBuilder.Entity<EntityGrid>()
                .HasMany(x => x.EntityColumns)
                .WithOne(x => x.EntityGrid)
                .HasForeignKey(x => x.EntityGridId);

            modelBuilder.Entity<EntityGrid>()
                .HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<EntityColumn>()
                .HasIndex(x => new { x.EntityGridId, x.PropertyName}).IsUnique(false);

            modelBuilder.Entity<Partner>().Navigation(x => x.Location).AutoInclude();
            modelBuilder.Entity<Partner>().Navigation(x => x.PartnerOffices).AutoInclude();

            modelBuilder.Entity<PartnerOffice>().Navigation(x => x.Location).AutoInclude();
            modelBuilder.Entity<PartnerOffice>().Navigation(x => x.Partner).AutoInclude();

            modelBuilder.Entity<Warehouse>().Navigation(x => x.Location).AutoInclude();

            modelBuilder.Entity<Good>().Navigation(x => x.UnitOfMeasure).AutoInclude();
            modelBuilder.Entity<Good>().Navigation(x => x.VatType).AutoInclude();

            modelBuilder.Entity<SalesInvoice>().Navigation(x => x.SalesInvoiceItems).AutoInclude();
            modelBuilder.Entity<SalesInvoice>().Navigation(x => x.Partner).AutoInclude();
            modelBuilder.Entity<SalesInvoice>().Navigation(x => x.PartnerOffice).AutoInclude();
            modelBuilder.Entity<SalesInvoice>().Navigation(x => x.Warehouse).AutoInclude();
            modelBuilder.Entity<SalesInvoiceItem>().Navigation(x => x.Good).AutoInclude();


            modelBuilder.Entity<GoodsReceivedNote>().Navigation(x => x.GoodsReceivedNoteItems).AutoInclude();
            modelBuilder.Entity<GoodsReceivedNote>().Navigation(x => x.Partner).AutoInclude();
            modelBuilder.Entity<GoodsReceivedNote>().Navigation(x => x.Warehouse).AutoInclude();
            modelBuilder.Entity<GoodsReceivedNote>().Navigation(x => x.PartnerOffice).AutoInclude();

            modelBuilder.Entity<VatType>().Navigation(x => x.Vats).AutoInclude();

            modelBuilder.Entity<EntityGrid>().Navigation(x => x.EntityColumns).AutoInclude();
        }
    }
}
