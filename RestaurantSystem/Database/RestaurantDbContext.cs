using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Models;

namespace RestaurantSystem.Database;

internal class RestaurantDbContext : DbContext
{
    public DbSet<Table> Tables { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=RestaurantSystem2.db");
        optionsBuilder.EnableSensitiveDataLogging(true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderProduct>()
            .HasOne(op => op.Order)
            .WithMany(o => o.Products)
            .HasForeignKey(op => op.OrderId);

        modelBuilder.Entity<OrderProduct>()
            .HasOne(op => op.Product)
            .WithMany(p => p.Orders)
            .HasForeignKey(op => op.ProductId);

        modelBuilder.Entity<Product>()
            .HasIndex(p => p.ProductId)
            .IsUnique();
    }
}