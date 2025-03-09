namespace SuperDiploma.Restaurant.DataContext.Entities.Models;

public class OrderItemDbo
{
    public int Id { get; set; }

    public int Quantity { get; set; }

    public int OrderId { get; set; }

    public OrderDbo Reservation { get; set; } //OrderItem належить одному Order.

    public int DishMenuItemId { get; set; }

    public DishMenuItemDbo DishMenuItem { get; set; } //OrderItem пов’язаний з одним DishMenuItem.
}