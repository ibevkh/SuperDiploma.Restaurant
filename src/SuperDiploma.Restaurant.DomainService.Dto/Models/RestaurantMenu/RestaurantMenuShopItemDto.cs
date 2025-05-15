namespace SuperDiploma.Restaurant.DomainService.Dto.Models.RestaurantMenu;

public class RestaurantMenuShopItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public byte[] Image { get; set; }
}