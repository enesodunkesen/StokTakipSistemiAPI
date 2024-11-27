using Microsoft.EntityFrameworkCore;


namespace StokTakipSistemiAPI.DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Transfer> Transfers { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>()
        //        .HasOne(p => p.Category)
        //        .WithMany(c => c.Products)
        //        .HasForeignKey(p => p.CategoryId);

        //    modelBuilder.Entity<Stock>()
        //        .HasOne(s => s.Product)
        //        .WithMany()
        //        .HasForeignKey(s => s.ProductId);

        //    modelBuilder.Entity<Stock>()
        //        .HasOne(s => s.Warehouse)
        //        .WithMany(w => w.Stocks)
        //        .HasForeignKey(s => s.WarehouseId);

        //    modelBuilder.Entity<StockMovement>()
        //        .HasOne(sm => sm.Product)
        //        .WithMany()
        //        .HasForeignKey(sm => sm.ProductId);

        //    modelBuilder.Entity<StockMovement>()
        //        .HasOne(sm => sm.Warehouse)
        //        .WithMany()
        //        .HasForeignKey(sm => sm.WarehouseId);

        //    modelBuilder.Entity<Sale>()
        //        .HasOne(s => s.Product)
        //        .WithMany()
        //        .HasForeignKey(s => s.ProductId);

        //    modelBuilder.Entity<Transfer>()
        //        .HasOne(t => t.Product)
        //        .WithMany()
        //        .HasForeignKey(t => t.ProductId);

        //    modelBuilder.Entity<Transfer>()
        //        .HasOne(t => t.FromWarehouse)
        //        .WithMany()
        //        .HasForeignKey(t => t.FromWarehouseId)
        //        .OnDelete(DeleteBehavior.NoAction); // Specify no cascade delete

        //    modelBuilder.Entity<Transfer>()
        //        .HasOne(t => t.ToWarehouse)
        //        .WithMany()
        //        .HasForeignKey(t => t.ToWarehouseId)
        //        .OnDelete(DeleteBehavior.NoAction); // Specify no cascade delete

        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasMany(e => e.Products)
                      .WithOne(p => p.Category)
                      .HasForeignKey(p => p.CategoryId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(150);
                entity.Property(e => e.Price)
                      .HasColumnType("decimal(18,2)");
                entity.Property(e => e.Size)
                      .HasMaxLength(50);
                entity.Property(e => e.Color)
                      .HasMaxLength(50);
                entity.Property(e => e.UpdatedAt)
                      .HasDefaultValueSql("GETDATE()");
            });

            // Sale
            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TotalAmount)
                      .HasColumnType("decimal(18,2)");
                entity.Property(e => e.Price)
                      .HasColumnType("decimal(18,2)");

                entity.HasOne(e => e.Product)
                      .WithMany()
                      .HasForeignKey(e => e.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Stock
            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UpdatedAt)
                      .HasDefaultValueSql("GETDATE()");

                entity.HasOne(e => e.Product)
                      .WithMany()
                      .HasForeignKey(e => e.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Warehouse)
                      .WithMany(w => w.Stocks)
                      .HasForeignKey(e => e.WarehouseId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // StockMovement
            modelBuilder.Entity<StockMovement>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.MovementType)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.HasOne(e => e.Product)
                      .WithMany()
                      .HasForeignKey(e => e.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Warehouse)
                      .WithMany()
                      .HasForeignKey(e => e.WarehouseId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Transfer
            modelBuilder.Entity<Transfer>(entity =>
            {
                entity.HasKey(e => e.TransferId);

                entity.HasOne(e => e.Product)
                      .WithMany()
                      .HasForeignKey(e => e.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.FromWarehouse)
                      .WithMany()
                      .HasForeignKey(e => e.FromWarehouseId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.ToWarehouse)
                      .WithMany()
                      .HasForeignKey(e => e.ToWarehouseId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Warehouse
            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100);
            });
        }

    }
}