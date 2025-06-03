using inventorySystem.domain.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace inventorySystem.infrastructure.persistence;

public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Operation> Operations { get; set; }
    public DbSet<Stock> Stocks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
         base.OnModelCreating(builder);

    // Operation -> Product (N:1)
    builder.Entity<Operation>()
        .HasOne(o => o.Product)
        .WithMany(p => p.Operations)
        .HasForeignKey(o => o.ProductId)
        .OnDelete(DeleteBehavior.Cascade);

    // Stock -> Product (N:1)
    builder.Entity<Stock>()
        .HasOne(s => s.Product)
        .WithMany(p => p.Stocks)
        .HasForeignKey(s => s.ProductId)
        .OnDelete(DeleteBehavior.Cascade);
        
    }
}
