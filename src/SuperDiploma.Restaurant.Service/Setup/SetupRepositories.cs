using FluentValidation;
using SuperDiploma.Core;
using SuperDiploma.Restaurant.DataContext.EF.Repositories;
using SuperDiploma.Restaurant.DataContext.Entities.Models;
using SuperDiploma.Restaurant.DomainService.Dto.Models.ShopItem;
using SuperDiploma.Restaurant.DomainService.Validators.ShopItems;

namespace SuperDiploma.Restaurant.Service.Setup;

public static class SetupRepositories
{
    public static IServiceCollection AddRestaurantRepositories(this IServiceCollection services)
    {
        return services
                .AddRepository<ShopItemDbo>()
                .AddRepository<ShopItemCategoryDbo>()
                .AddRepository<OrderDbo>()
                .AddTempRepository<OrderItemDbo>()
            ;
    }
}