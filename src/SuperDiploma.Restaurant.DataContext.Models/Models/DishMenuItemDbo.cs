namespace SuperDiploma.Restaurant.DataContext.Entities.Models;

public class DishMenuItemDbo
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }

    public int CategoryId { get; set; }

    public CategoryDbo Category { get; set; } //DishMenuItem належить одній Category.

    public ICollection<OrderItemDbo> OrderItems { get; set; } //DishMenuItem може бути у багатьох OrderItem.
}