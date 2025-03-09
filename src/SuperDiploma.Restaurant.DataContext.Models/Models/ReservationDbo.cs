namespace SuperDiploma.Restaurant.DataContext.Entities.Models;

public class ReservationDbo
{
    public int Id { get; set; }
    public DateTime ReservationTime { get; set; }
    public DateTime CreatedAt { get; set; }

    public int CustomerId { get; set; }
    public CustomerDbo Customer { get; set; } // Reservation належить одному Customer.

    public int TableId { get; set; } 
    public TableDbo Table { get; set; } // Reservation належить одному столику.

}