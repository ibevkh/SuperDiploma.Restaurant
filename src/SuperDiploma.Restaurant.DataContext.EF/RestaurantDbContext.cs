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

    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        // DishMenuItemDbo
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

        // CustomerDbo
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

        // OrderDbo
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

        // OrderItemDbo
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

        // TableDbo
        modelBuilder.Entity<TableDbo>()
            .HasKey(t => t.Id);

        modelBuilder.Entity<TableDbo>()
            .Property(t => t.TableNumber)
            .IsRequired();

        modelBuilder.Entity<TableDbo>()
            .Property(t => t.IsAvailable)
            .IsRequired();

        // ReservationDbo
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
            .HasForeignKey(r => r.TableId)
            .OnDelete(DeleteBehavior.Restrict); // Не дозволяємо видаляти стіл, якщо є бронювання

        modelBuilder.Entity<TableDbo>().HasData(
            new TableDbo { Id = 1, TableNumber = 1, Capacity = 4, IsAvailable = true },
            new TableDbo { Id = 2, TableNumber = 2, Capacity = 4, IsAvailable = true },
            new TableDbo { Id = 3, TableNumber = 3, Capacity = 4, IsAvailable = true },
            new TableDbo { Id = 4, TableNumber = 4, Capacity = 4, IsAvailable = true },
            new TableDbo { Id = 5, TableNumber = 5, Capacity = 6, IsAvailable = true },
            new TableDbo { Id = 6, TableNumber = 6, Capacity = 6, IsAvailable = true },
            new TableDbo { Id = 7, TableNumber = 7, Capacity = 6, IsAvailable = true },
            new TableDbo { Id = 8, TableNumber = 8, Capacity = 8, IsAvailable = true },
            new TableDbo { Id = 9, TableNumber = 9, Capacity = 8, IsAvailable = true },
            new TableDbo { Id = 10, TableNumber = 10, Capacity = 2, IsAvailable = true },
            new TableDbo { Id = 11, TableNumber = 11, Capacity = 2, IsAvailable = true }
        );

        modelBuilder.Entity<CategoryDbo>().HasData(
            new CategoryDbo { Id = 1, Name = "Перші страви" },
            new CategoryDbo { Id = 2, Name = "Другі страви" },
            new CategoryDbo { Id = 3, Name = "Десерти" },
            new CategoryDbo { Id = 4, Name = "Салати" }
        );
    }
}