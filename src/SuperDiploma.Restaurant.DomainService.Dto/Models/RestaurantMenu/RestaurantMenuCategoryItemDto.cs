namespace SuperDiploma.Restaurant.DomainService.Dto.Models.RestaurantMenu;

public class RestaurantMenuCategoryItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<RestaurantMenuShopItemDto> Items { get; set; }
}