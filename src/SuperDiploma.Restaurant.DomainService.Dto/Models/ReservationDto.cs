namespace SuperDiploma.Restaurant.DomainService.Dto.Models;

public class ReservationDto
{
    public int Id { get; set; }
    public DateTime ReservationTime { get; set; }
    public int CustomerId { get; set; }
    public int GuestCount { get; set; }
    public int TotalGuestCount { get; set; }
    public int AvailableGuestCount { get; set; }
}