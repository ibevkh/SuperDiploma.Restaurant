namespace SuperDiploma.Restaurant.DomainService.Dto.Models;

public class OrderDto
{
    public int Id { get; set; }
    public DateTime OrderTime { get; set; }
    public decimal TotalPrice { get; set; }
    public string Status { get; set; }
    public int CustomerId { get; set; }
    //public int? ReservationId { get; set; }
    public ReservationDto Reservation { get; set; }
}