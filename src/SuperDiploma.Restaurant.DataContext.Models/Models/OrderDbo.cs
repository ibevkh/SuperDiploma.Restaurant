using System.ComponentModel.DataAnnotations;

namespace SuperDiploma.Restaurant.DataContext.Entities.Models;

public class OrderDbo
{
    public int Id { get; set; }

    public DateTime OrderTime { get; set; }

    [Range(0, 100000)]
    public decimal TotalPrice { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CustomerId { get; set; }

    public CustomerDbo Customer { get; set; } //Order належить одному Customer.

    public int? ReservationId { get; set; }

    public ReservationDbo Reservation { get; set; } //Order може бути прив'язаний до Reservation, або не мати його.

    public ICollection<OrderItemDbo> OrderItems { get; set; } //Order може містити багато OrderItem.
}