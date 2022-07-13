namespace WCWebService.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SalesContext : DbContext
    {
        public SalesContext()
            : base("name=SalesContext")
        {
        }

        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<tCieMap> tCieMaps { get; set; }
        public virtual DbSet<RefreshDate> RefreshDates { get; set; }
        public virtual DbSet<xferLog> xferLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>()
                .Property(e => e.fNetSales)
                .HasPrecision(10, 4);

            modelBuilder.Entity<Sale>()
                .Property(e => e.fNetCost)
                .HasPrecision(10, 4);
        }
    }
}
