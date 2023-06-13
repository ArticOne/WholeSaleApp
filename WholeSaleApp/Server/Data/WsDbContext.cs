using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
                .WithMany()
                .IsRequired();

            modelBuilder.Entity<Good>()
                .HasOne<Vat>(g => g.Vat)
                .WithMany()
                .IsRequired();

            modelBuilder.Entity<Partner>().Navigation(x => x.Location).AutoInclude();
            modelBuilder.Entity<Partner>().Navigation(x => x.PartnerOffices).AutoInclude();
            modelBuilder.Entity<PartnerOffice>().Navigation(x => x.Location).AutoInclude();
            modelBuilder.Entity<PartnerOffice>().Navigation(x => x.Partner).AutoInclude();
            modelBuilder.Entity<Warehouse>().Navigation(x => x.Location).AutoInclude();
            modelBuilder.Entity<Good>().Navigation(x => x.UnitOfMeasure).AutoInclude();
            modelBuilder.Entity<Good>().Navigation(x => x.Vat).AutoInclude();
        }
    }
}
