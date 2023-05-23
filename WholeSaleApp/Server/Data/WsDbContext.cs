using Microsoft.EntityFrameworkCore;
using WholeSaleApp.Shared.Model.CodeBook;
using WholeSaleApp.Shared.Model.Documents.Invoices;
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
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

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
                .HasOne<VatType>(v => v.VatType)
                .WithOne()
                .IsRequired();
        }
    }
}
