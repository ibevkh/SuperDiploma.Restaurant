using SuperDiploma.Restaurant.DomainService.Dto.Models.RestaurantMenu;

namespace SuperDiploma.Restaurant.DomainService.Contracts;

public interface IRestaurantMenuService
{
    Task<IEnumerable<RestaurantMenuCategoryItemDto>> GetRestaurantMenu();
}