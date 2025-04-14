using AutoMapper;
using SuperDiploma.Restaurant.DataContext.EF;
using SuperDiploma.Restaurant.DataContext.Entities.Models;
using SuperDiploma.Restaurant.DomainService.Contracts;
using SuperDiploma.Restaurant.DomainService.Dto.Models;

namespace SuperDiploma.Restaurant.DomainService;

public class ShopItemCategoryService
    : GenericShopItem<ShopItemCategoryDbo, ShopItemCategoryFormDto>, IShopItemCategoryService
{
    public ShopItemCategoryService(IRestaurantUnitOfWork myUnitOfWork, IAuthService authService, IMapper mapper)
        : base(myUnitOfWork, authService, mapper)
    {
    }
}