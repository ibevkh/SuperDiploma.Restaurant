using SuperDiploma.Restaurant.DomainService;
using SuperDiploma.Restaurant.DomainService.Contracts;

namespace SuperDiploma.Restaurant.Service.Setup;

public static class SetupServices
{
    public static IServiceCollection AddRestaurantServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IShopItemCategoryService, ShopItemCategoryService>()
            .AddScoped<IShopItemService, ShopItemService>()
            .AddScoped<IAuthService, AuthService>()
            .AddScoped<IRestaurantMenuService, RestaurantMenuService>()
            .AddScoped<IOrderService, OrderService>()
            ;
    }
}