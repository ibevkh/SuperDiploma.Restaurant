using SuperDiploma.Core.Models;

namespace SuperDiploma.Restaurant.DataContext.Entities.Models;

public class ShopItemCategoryDbo : SuperDiplomaBaseDbo
{
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual ICollection<ShopItemDbo> ShopItems { get; set; }
}