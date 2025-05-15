using SuperDiploma.Restaurant.DomainService.Dto.Models;
using SuperDiploma.Restaurant.DomainService.Dto.Models.Order;

public class OrderGridDto
{
    public int Id { get; set; }

    // Customer Info
    public string CustomerName { get; set; }
    public string CustomerPhoneNumber { get; set; }
    public string CustomerAddress { get; set; }
    public int Entrance { get; set; }
    public int ApartmentNumber { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    // Order Items
    public IEnumerable<OrderItemGridDto> Items { get; set; }
}