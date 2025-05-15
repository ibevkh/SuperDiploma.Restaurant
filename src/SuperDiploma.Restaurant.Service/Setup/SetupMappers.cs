using SuperDiploma.Restaurant.DomainService.Dto.Mappings;

namespace SuperDiploma.Restaurant.Service.Setup;

public static class SetupMappers
{
    public static IServiceCollection AddRestaurantMappers(this IServiceCollection services)
    {
        return services
                .AddAutoMapper(typeof(RestaurantMapping))
                .AddAutoMapper(typeof(ShopItemMapping))
                .AddAutoMapper(typeof(DatasourceMapping))
                .AddAutoMapper(typeof(PaginatedResponseMapping))
                .AddAutoMapper(typeof(ShopItemCategoryMapping))
                .AddAutoMapper(typeof(OrderMapping))
            ;
    }
}