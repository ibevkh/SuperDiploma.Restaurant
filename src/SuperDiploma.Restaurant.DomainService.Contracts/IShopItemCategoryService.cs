using SuperDiploma.Restaurant.DataContext.Entities.Models;
using SuperDiploma.Restaurant.DomainService.Dto.Models;
using SuperDiploma.Restaurant.DomainService.Dto.Models.CategoryShopItem;
using SuperDiploma.Restaurant.DomainService.Dto.Models.ShopItem;

namespace SuperDiploma.Restaurant.DomainService.Contracts;

public interface IShopItemCategoryService : IGenericShopItem<ShopItemCategoryDbo, ShopItemCategoryFormDto>
{
    //Task<ShopItemCategoryFormDto> GetCategoryByIdAsync(int id);
    //Task<ShopItemCategoryFormDto> CreateOrUpdateCategoryAsync(ShopItemCategoryFormDto category);
    //Task<ShopItemCategoryFormDto> RemoveCategoryAsync(int id);
    Task<PaginatedResponseDto<IEnumerable<ShopItemCategoryGridDto>>> GetListAsync(ShopItemCategoryGridFilterDto filter);
}