using SuperDiploma.Restaurant.DomainService.Dto.Models;
using SuperDiploma.Restaurant.DomainService.Dto.Models.Order;

public class OrderGridDto
{
    public int Id { get; set; }

    // Customer Info
    public string CustomerName { get; set; }
    public string CustomerPhoneNumber { get; set; }
    public string DeliveryAddress { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTimeOffset DeliveryTime { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    // Order Items
    public IEnumerable<OrderItemGridDto> Items { get; set; }
}