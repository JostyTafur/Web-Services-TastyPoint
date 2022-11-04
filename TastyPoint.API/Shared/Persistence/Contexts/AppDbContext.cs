using Microsoft.EntityFrameworkCore;
using TastyPoint.API.Ordering.Domain.Models;
using TastyPoint.API.Shared.Extensions;

namespace TastyPoint.API.Shared.Persistence.Contexts;

public class AppDbContext: DbContext
{
    
    public DbSet<Order> Orders { get; set; }
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

      
        
        //Order Entity Mapping Configuration
        builder.Entity<Order>().ToTable("Orders");
        builder.Entity<Order>().HasKey(p => p.Id);
        builder.Entity<Order>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Order>().Property(p => p.Status).IsRequired().HasMaxLength(100);
        builder.Entity<Order>().Property(p => p.Restaurant).IsRequired().HasMaxLength(100);
        builder.Entity<Order>().Property(p => p.DeliveryMethod).IsRequired().HasMaxLength(100);
        builder.Entity<Order>().Property(p => p.PaymentMethod).IsRequired().HasMaxLength(100);

        

        builder.UseSnakeCaseNamingConvention();
    }
    
}