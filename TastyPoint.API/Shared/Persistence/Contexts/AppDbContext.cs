using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using TastyPoint.API.Publishing.Domain.Models;
using TastyPoint.API.Selling.Domain.Models;
using TastyPoint.API.Ordering.Domain.Models;
using TastyPoint.API.Security.Domain.Models;

using TastyPoint.API.Shared.Extensions;

namespace TastyPoint.API.Shared.Persistence.Contexts;

public class AppDbContext: DbContext
{
    public DbSet<Pack> Packs { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        //Product Entity Mapping Configuration
        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>().HasKey(p => p.Id);
        builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Entity<Product>().Property(p => p.Type).IsRequired().HasMaxLength(50);

        //Pack Entity Mapping Configuration
        builder.Entity<Pack>().ToTable("Packs");
        builder.Entity<Pack>().HasKey(p => p.Id);
        builder.Entity<Pack>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Pack>().Property(p => p.Name).IsRequired().HasMaxLength(100);
        
        //Promotion Entity Mapping Configuration
        builder.Entity<Promotion>().ToTable("Promotions");
        builder.Entity<Promotion>().HasKey(p => p.Id);
        builder.Entity<Promotion>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Promotion>().Property(p => p.Title).IsRequired().HasMaxLength(100);
        builder.Entity<Promotion>().Property(p => p.SubTitle).IsRequired().HasMaxLength(150);
        builder.Entity<Promotion>().Property(p => p.Description).IsRequired().HasMaxLength(500);
        builder.Entity<Promotion>().Property(p => p.Image).IsRequired().HasMaxLength(100);
        builder.Entity<Promotion>().Property(p => p.PackId).IsRequired();

        //Order Entity Mapping Configuration
        builder.Entity<Order>().ToTable("Orders");
        builder.Entity<Order>().HasKey(p => p.Id);
        builder.Entity<Order>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Order>().Property(p => p.Status).IsRequired().HasMaxLength(100);
        builder.Entity<Order>().Property(p => p.Restaurant).IsRequired().HasMaxLength(100);
        builder.Entity<Order>().Property(p => p.DeliveryMethod).IsRequired().HasMaxLength(100);
        builder.Entity<Order>().Property(p => p.PaymentMethod).IsRequired().HasMaxLength(100);
        
        // User Entity Mapping Configuration
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.Username).IsRequired().HasMaxLength(30);
        builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(30);

        
        //Relationships
        builder.Entity<Pack>()
            .HasMany(p => p.Products)
            .WithOne(p => p.Pack)
            .HasForeignKey(p => p.PackId);

        base.OnModelCreating(builder);
        builder.UseSnakeCaseNamingConvention();
    }
}