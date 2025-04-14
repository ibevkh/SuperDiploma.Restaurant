using SuperDiploma.Restaurant.DataContext.Entities.Models;
using SuperDiploma.Restaurant.DomainService.Dto.Models;
using SuperDiploma.Restaurant.DomainService.Dto.Models.ShopItem;

namespace SuperDiploma.Restaurant.DomainService.Contracts;

public interface IShopItemService : IGenericShopItem<ShopItemDbo, ShopItemFormDto>
{
    Task<PaginatedResponseDto<IEnumerable<ShopItemListItemDto>>> GetFilteredListAsync(ShopItemGridFilterDto filter);
    Task<ShopItemPreviewDto?> GetPreviewByIdAsync(int id);
    //Task<ShopItemFormDto?> GetItemByIdAsync(int id);
    Task<ShopItemFilterDatasourceDto> GetGridDataSourcesAsync();
    Task<ShopItemFormDatasourceDto> GetFormDataSourcesAsync();
    //Task<ShopItemFormDto> CreateOrUpdateItemAsync(ShopItemFormDto item);
    //Task<ShopItemFormDto> RemoveItemAsync(int id);
}