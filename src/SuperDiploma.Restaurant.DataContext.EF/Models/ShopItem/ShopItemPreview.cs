namespace SuperDiploma.Restaurant.DataContext.EF.Models.ShopItem;

public class ShopItemPreview
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int StateId { get; set; }
    public string CategoryName { get; set; }
    public string CategoryDescription { get; set; }
    public byte[] Image { get; set; }
}