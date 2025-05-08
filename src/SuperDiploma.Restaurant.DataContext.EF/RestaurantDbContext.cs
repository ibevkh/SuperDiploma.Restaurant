using Microsoft.EntityFrameworkCore;
using SuperDiploma.Restaurant.DataContext.Entities.Models;

namespace SuperDiploma.Restaurant.DataContext.EF;

public class RestaurantDbContext : DbContext
{
    public DbSet<CategoryDbo> Categories { get; set; }
    public DbSet<DishMenuItemDbo> Dishes { get; set; }
    public DbSet<OrderItemDbo> OrderItems { get; set; }
    public DbSet<OrderDbo> OrderOrders { get; set; }
    public DbSet<ReservationDbo> Reservations { get; set; }
    public DbSet<CustomerDbo> CustomerOrders { get; set; }

   
    public DbSet<ShopItemCategoryDbo> ShopItemCategories { get; set; }
    public DbSet<ShopItemDbo> ShopItems { get; set; }

    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ShopItemCategoryDbo>().Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");
        modelBuilder.Entity<ShopItemCategoryDbo>().Property(p => p.ModifiedAt).HasDefaultValueSql("GETDATE()");
        modelBuilder.Entity<ShopItemCategoryDbo>().Property(p => p.Name).HasMaxLength(50);
        modelBuilder.Entity<ShopItemCategoryDbo>().Property(p => p.Description).HasMaxLength(500);
        modelBuilder.Entity<ShopItemCategoryDbo>().Property(p => p.IsDeleted).HasDefaultValue(false);
        modelBuilder.Entity<ShopItemCategoryDbo>().HasKey(p => p.Id);

        modelBuilder.Entity<ShopItemCategoryDbo>().ToTable("ShopItemCategories", "md");

        modelBuilder.Entity<ShopItemDbo>().Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()").IsRequired();
        modelBuilder.Entity<ShopItemDbo>().Property(p => p.ModifiedAt).HasDefaultValueSql("GETDATE()").IsRequired();
        modelBuilder.Entity<ShopItemDbo>().Property(p => p.CreatedBy).IsRequired();
        modelBuilder.Entity<ShopItemDbo>().Property(p => p.ModifiedBy).IsRequired();
        modelBuilder.Entity<ShopItemDbo>().Property(p => p.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<ShopItemDbo>().Property(p => p.Description).HasMaxLength(500);
        modelBuilder.Entity<ShopItemDbo>().Property(p => p.Price).IsRequired();
        modelBuilder.Entity<ShopItemDbo>().Property(p => p.IsDeleted).HasDefaultValue(false).IsRequired();
        modelBuilder.Entity<ShopItemDbo>().ToTable("ShopItems", "md");


        modelBuilder.Entity<ShopItemCategoryDbo>().HasData(
            Enumerable.Range(1, 15).Select(s => new ShopItemCategoryDbo { Id = s, Name = $"Категорія {s}", Description = $"Якийсь опис {s}", CreatedBy = 1, ModifiedBy = 1 })
        );

        modelBuilder.Entity<ShopItemDbo>().HasData(
            Enumerable.Range(1, 15).Select(s => new ShopItemDbo { Id = s, Name = $"Товар {s}", Description = $"Якийсь опис {s}", Price = 100, CreatedBy = 1, ModifiedBy = 1, CategoryId = (s < 7) ? 1 : 2, StateId = (s > 7) ? 1 : 2 })
        );

        // AdminDbo
        modelBuilder.Entity<AdminDbo>()
            .HasKey(a => a.Id);

        modelBuilder.Entity<AdminDbo>()
            .Property(a => a.Username)
            .IsRequired();

        modelBuilder.Entity<AdminDbo>()
            .Property(a => a.PasswordHash)
            .IsRequired();

        modelBuilder.Entity<AdminDbo>()
            .Property(a => a.Role)
            .IsRequired();

        // CategoryDbo
        modelBuilder.Entity<CategoryDbo>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<CategoryDbo>()
            .Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        modelBuilder.Entity<DishMenuItemDbo>()
            .HasKey(d => d.Id);

        modelBuilder.Entity<DishMenuItemDbo>()
            .Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<DishMenuItemDbo>()
            .Property(d => d.Description)
            .HasMaxLength(500);

        modelBuilder.Entity<DishMenuItemDbo>()
            .Property(d => d.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<DishMenuItemDbo>()
            .HasOne(d => d.Category)
            .WithMany()
            .HasForeignKey(d => d.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CustomerDbo>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<CustomerDbo>()
            .Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<CustomerDbo>()
            .Property(c => c.Phone)
            .IsRequired()
            .HasMaxLength(10);

        modelBuilder.Entity<CustomerDbo>()
            .Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<CustomerDbo>()
            .Property(c => c.Address)
            .IsRequired()
            .HasMaxLength(120);

        modelBuilder.Entity<CustomerDbo>()
            .Property(c => c.Entrance)
            .HasDefaultValue(1);

        modelBuilder.Entity<CustomerDbo>()
            .Property(c => c.ApartmentNumber)
            .HasDefaultValue(1);

        modelBuilder.Entity<OrderDbo>()
            .HasKey(o => o.Id);

        modelBuilder.Entity<OrderDbo>()
            .Property(o => o.OrderTime)
            .IsRequired();

        modelBuilder.Entity<OrderDbo>()
            .Property(o => o.TotalPrice)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<OrderDbo>()
            .Property(o => o.CreatedAt)
            .IsRequired();

        modelBuilder.Entity<OrderDbo>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrderDbo>()
            .HasOne(o => o.Reservation)
            .WithMany()
            .HasForeignKey(o => o.ReservationId)
            .IsRequired(false);

        modelBuilder.Entity<OrderItemDbo>()
            .HasKey(oi => oi.Id);

        modelBuilder.Entity<OrderItemDbo>()
            .Property(oi => oi.Quantity)
            .IsRequired()
            .HasDefaultValue(1);

        modelBuilder.Entity<OrderItemDbo>()
            .HasOne(oi => oi.Reservation)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrderItemDbo>()
            .HasOne(oi => oi.DishMenuItem)
            .WithMany(d => d.OrderItems)
            .HasForeignKey(oi => oi.DishMenuItemId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TableDbo>()
            .HasKey(t => t.Id);

        modelBuilder.Entity<TableDbo>()
            .Property(t => t.TableNumber)
            .IsRequired();

        modelBuilder.Entity<TableDbo>()
            .Property(t => t.IsAvailable)
            .IsRequired();

        modelBuilder.Entity<ReservationDbo>()
            .HasKey(r => r.Id);

        modelBuilder.Entity<ReservationDbo>()
            .Property(r => r.ReservationTime)
            .IsRequired();

        modelBuilder.Entity<ReservationDbo>()
            .Property(r => r.CreatedAt)
            .IsRequired();

        modelBuilder.Entity<ReservationDbo>()
            .HasOne(r => r.Customer)
            .WithMany(c => c.Reservations)
            .HasForeignKey(r => r.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ReservationDbo>()
            .HasOne(r => r.Table)
            .WithMany(t => t.Reservations)
            .HasForeignKey(r => r.TableId);

    }
}