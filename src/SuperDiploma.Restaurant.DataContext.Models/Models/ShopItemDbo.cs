using SuperDiploma.Core.Models;

namespace SuperDiploma.Restaurant.DataContext.Entities.Models;

public class ShopItemDbo : SuperDiplomaBaseDbo
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int StateId { get; set; }
    public byte[] Image { get; set; }

    public int CategoryId { get; set; }
    public ShopItemCategoryDbo Category { get; set; }
}