namespace SuperDiploma.Restaurant.DomainService.Dto.Models.Order;

public class OrderRequestDto
{
    public int? Id { get; set; }
    public string CustomerName { get; set; }
    public string CustomerPhoneNumber { get; set; }
    public string DeliveryAddress { get; set; }
    public DateTimeOffset DeliveryTime { get; set; }
    public IEnumerable<OrderItemGridDto> Items { get; set; }
}