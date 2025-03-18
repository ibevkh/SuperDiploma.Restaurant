namespace SuperDiploma.Restaurant.DataContext.Entities.Models;

public class ShopItemCategoryDbo : BaseRemovableDbo
{
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual ICollection<ShopItemDbo> ShopItems { get; set; }
}