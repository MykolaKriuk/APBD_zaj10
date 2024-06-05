using APBD_zaj10.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_zaj10.Contexts;

public class DatabaseContext : DbContext
{
    
    public DbSet<Role> Roles { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ShoppingCart>()
            .HasKey(sc => new { sc.AccountId, sc.ProductId });

        modelBuilder.Entity<ShoppingCart>()
            .HasOne(sc => sc.Account)
            .WithMany(a => a.ShoppingCarts)
            .HasForeignKey(sc => sc.AccountId);

        modelBuilder.Entity<ShoppingCart>()
            .HasOne(sc => sc.Product)
            .WithMany(p => p.ShoppingCarts)
            .HasForeignKey(sc => sc.ProductId);

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(pc => new { pc.ProductId, pc.CategoryId });
        });

        base.OnModelCreating(modelBuilder);
    }
}