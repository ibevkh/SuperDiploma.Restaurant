using SuperDiploma.Restaurant.DataContext.EF;
using SuperDiploma.Restaurant.DataContext.EF.Repositories;
using SuperDiploma.Restaurant.DataContext.Entities.Models;
using SuperDiploma.Restaurant.DomainService.Contracts;
using SuperDiploma.Restaurant.DomainService.Dto.Models.RestaurantMenu;

namespace SuperDiploma.Restaurant.DomainService;

public class RestaurantMenuService : IRestaurantMenuService
{
    private readonly IRestaurantUnitOfWork _unitOfWork;

    public RestaurantMenuService(IRestaurantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<RestaurantMenuCategoryItemDto>> GetRestaurantMenu()
    {
        var categories = await _unitOfWork.Repository<ShopItemCategoryDbo>()
            .GetListWithShopItemAsync();

        return categories.Select(s => new RestaurantMenuCategoryItemDto
        {
            Id = s.Id,
            Name = s.Name,
            Description = s.Description,
            Items = s.ShopItems.Select(i => new RestaurantMenuShopItemDto
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description,
                Price = i.Price,
                Image = i.Image
            }),
        });
    }
}