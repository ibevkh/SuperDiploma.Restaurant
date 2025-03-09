using SuperDiploma.Restaurant.DomainService.Dto.Models;

namespace SuperDiploma.Restaurant.DomainService.Contracts;

public interface IDishService
{
    Task<IEnumerable<DishMenuItemDto>> GetDishMenuItemByCategory(int categoryId);
    Task<DishMenuItemDto> AddCategoryAsync(DishMenuItemDto dishDto);
    Task<DishMenuItemDto> UpdateCategoryAsync(DishMenuItemDto dishDto);
    Task DeleteCategoryAsync(int id);
}