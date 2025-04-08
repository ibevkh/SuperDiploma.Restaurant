using FluentValidation;
using SuperDiploma.Restaurant.DomainService.Dto.Models.ShopItem;
using SuperDiploma.Restaurant.DomainService.Validators.ShopItems;

namespace SuperDiploma.Restaurant.Service.Setup;

public static class SetupValidators
{
    public static IServiceCollection AddRestaurantValidators(this IServiceCollection services)
    {
        return services
                .AddScoped<IValidator<ShopItemFormDto>, ShopItemFormValidator>()
                
            ;
                
    }
}