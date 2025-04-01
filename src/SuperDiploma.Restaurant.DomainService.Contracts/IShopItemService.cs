using SuperDiploma.Restaurant.DomainService.Dto.Models;
using SuperDiploma.Restaurant.DomainService.Dto.Models.ShopItem;

namespace SuperDiploma.Restaurant.DomainService.Contracts;

public interface IShopItemService
{
    Task<PaginatedResponseDto<IEnumerable<ShopItemListItemDto>>> GetFilteredListAsync(ShopItemGridFilterDto filter);
    Task<ShopItemPreviewDto> GetPreviewByIdAsync(int id);
    Task<ShopItemFormDto> GetByIdAsync(int id);
    Task<ShopItemFilterDatasourceDto> GetFilterDataSourcesAsync();
    Task<ShopItemFormDatasourceDto> GetFormDataSourcesAsync();
}