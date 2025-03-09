namespace SuperDiploma.Restaurant.DataContext.Entities.Models;

public class CustomerDbo
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Phone { get; set; }

    public string Email { get; set; }

    public string Address { get; set; }

    public int Entrance { get; set; } // Під'їзд (необов'язкове поле)

    public int ApartmentNumber { get; set; } // Номер квартири (необов'язкове поле)

    public ICollection<OrderDbo> Orders { get; set; } //Один Customer може мати багато Order.

    public ICollection<ReservationDbo> Reservations { get; set; } //Один Customer може мати багато Reservation.
}