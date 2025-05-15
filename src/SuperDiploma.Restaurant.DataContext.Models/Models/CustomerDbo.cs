using SuperDiploma.Core.Models;

namespace SuperDiploma.Restaurant.DataContext.Entities.Models;

public class CustomerDbo : SuperDiplomaBaseDbo
{
    //public int Id { get; set; }

    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    public string Address { get; set; }

    public int Entrance { get; set; }

    public int ApartmentNumber { get; set; }

    public virtual ICollection<OrderDbo> Orders { get; set; } // також virtual
}
