namespace SuperDiploma.Restaurant.DataContext.EF.Models.ShopItem;

public class ShopItemGridFilter
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public int? CategoryId { get; set; }
    public int? StateId { get; set; }
}