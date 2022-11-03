using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WholeSaleApp.Shared.Model.CodeBook;
using WholeSaleApp.Shared.Model.Documents.Invoices;

namespace WholeSaleApp.Server.Data
{
    public class WsDbContext : DbContext
    {
        public DbSet<Good> Goods { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<PartnerOffice> PartnerOffices { get; set; }
        public DbSet<UnitOfMeasure> UnitsOfMeasure { get; set; }
        public DbSet<VatType> VatTypes { get; set; }
        public DbSet<Vat> Vats { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder
           .UseSqlServer("Data Source=DESKTOP-BUSTMRG;Initial Catalog=WholeSaleApp;Integrated Security=true;User Id=sa;Password=c2");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Good>()
                .HasOne<UnitOfMeasure>(g => g.UnitOfMeasure)
                .WithOne()
                .IsRequired();
            modelBuilder.Entity<Partner>()
                .HasOne<Location>(p => p.Location)
                .WithOne()
                .IsRequired();
            modelBuilder.Entity<PartnerOffice>()
                .HasOne<Location>(po => po.Location)
                .WithOne();
            modelBuilder.Entity<PartnerOffice>()
                .HasOne<Partner>(po => po.Partner)
                .WithOne()
                .IsRequired();
            modelBuilder.Entity<Vat>()
                .HasOne<Good>(v => v.VatType)
                .WithOne()
                .IsRequired();
        }
    }
}
