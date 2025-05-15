using SuperDiploma.Core.Models;

namespace SuperDiploma.Restaurant.DataContext.Entities.Models;

public class OrderItemDbo
{
    //public int Id { get; set; }
    public int Quantity { get; set; }
    public int OrderId { get; set; }
    public virtual OrderDbo Order { get; set; }
    public int ShopItemId { get; set; }
    public virtual ShopItemDbo ShopItem { get; set; }
}