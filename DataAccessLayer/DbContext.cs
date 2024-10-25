using Microsoft.EntityFrameworkCore;

namespace StockManagementSystem.DataAccessLayer
{
    public class StockManagementContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Transfer> Transfers { get; set; }

        public StockManagementContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        //TODO
        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasRequired(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Stock>()
                .HasRequired(s => s.Product)
                .WithMany()
                .HasForeignKey(s => s.ProductId);

            modelBuilder.Entity<Stock>()
                .HasRequired(s => s.Warehouse)
                .WithMany(w => w.Stocks)
                .HasForeignKey(s => s.WarehouseId);

            modelBuilder.Entity<StockMovement>()
                .HasRequired(sm => sm.Product)
                .WithMany()
                .HasForeignKey(sm => sm.ProductId);

            modelBuilder.Entity<StockMovement>()
                .HasRequired(sm => sm.Warehouse)
                .WithMany()
                .HasForeignKey(sm => sm.WarehouseId);

            modelBuilder.Entity<Sale>()
                .HasRequired(s => s.Product)
                .WithMany()
                .HasForeignKey(s => s.ProductId);

            modelBuilder.Entity<Transfer>()
                .HasRequired(t => t.Product)
                .WithMany()
                .HasForeignKey(t => t.ProductId);

            modelBuilder.Entity<Transfer>()
                .HasRequired(t => t.FromWarehouse)
                .WithMany()
                .HasForeignKey(t => t.FromWarehouseId);

            modelBuilder.Entity<Transfer>()
                .HasRequired(t => t.ToWarehouse)
                .WithMany()
                .HasForeignKey(t => t.ToWarehouseId);
        }*/
    }
}