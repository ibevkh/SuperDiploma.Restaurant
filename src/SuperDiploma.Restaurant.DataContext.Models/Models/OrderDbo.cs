using SuperDiploma.Core.Models;

namespace SuperDiploma.Restaurant.DataContext.Entities.Models;

public class OrderDbo : SuperDiplomaBaseDbo
{
    public string CustomerPhoneNumber { get; set; }
    public string CustomerName { get; set; }
    public string DeliveryAddress { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTimeOffset DeliveryTime { get; set; }
    public int? CustomerId { get; set; }
    //public virtual CustomerDbo Customer { get; set; }
    public virtual ICollection<OrderItemDbo> OrderItems { get; set; } 
}
