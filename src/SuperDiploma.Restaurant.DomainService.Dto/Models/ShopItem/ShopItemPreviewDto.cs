using SuperDiploma.Restaurant.DomainService.Enums;

namespace SuperDiploma.Restaurant.DomainService.Dto.Models.ShopItem;

public class ShopItemPreviewDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ShopItemState State { get; set; }
    public string CategoryName { get; set; }
    public string CategoryDescription { get; set; }
    public byte[] Image { get; set; }
    public decimal Price { get; set; }
}