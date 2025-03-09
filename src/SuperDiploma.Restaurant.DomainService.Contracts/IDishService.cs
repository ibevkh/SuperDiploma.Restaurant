using SuperDiploma.Restaurant.DomainService.Dto.Models;

namespace SuperDiploma.Restaurant.DomainService.Contracts;

public interface IDishService
{
    Task<IEnumerable<DishMenuItemDto>> GetDishMenuItemByCategory(int categoryId);
    Task<DishMenuItemDto> AddDishAsync(DishMenuItemDto dishDto);
    Task<DishMenuItemDto> UpdateDishAsync(DishMenuItemDto dishDto);
    Task DeleteDishAsync(DishMenuItemDto dishDto);
}