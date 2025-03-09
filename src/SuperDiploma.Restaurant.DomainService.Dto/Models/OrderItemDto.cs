namespace SuperDiploma.Restaurant.DomainService.Dto.Models;

public class OrderItemDto
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int OrderId { get; set; }
}