namespace SuperDiploma.Restaurant.DataContext.Entities.Models;

public class TableDbo
{
    public int Id { get; set; }
    public int TableNumber { get; set; }
    public bool IsAvailable { get; set; }
    public int Capacity { get; set; }
    public ICollection<ReservationDbo> Reservations { get; set; }
}