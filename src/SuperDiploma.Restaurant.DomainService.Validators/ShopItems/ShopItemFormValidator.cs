using FluentValidation;
using SuperDiploma.Restaurant.DomainService.Dto.Models.ShopItem;

namespace SuperDiploma.Restaurant.DomainService.Validators.ShopItems;

public class ShopItemFormValidator : AbstractValidator<ShopItemFormDto>
{
    public ShopItemFormValidator()
    {
        RuleSet("create", () =>
        {
            RuleFor(x => x.Name).NotEmpty();
        });

        RuleFor(x => x.Name).NotEmpty();
    }
}