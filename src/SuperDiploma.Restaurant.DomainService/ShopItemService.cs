using AutoMapper;
using SuperDiploma.Restaurant.DataContext.EF;
using SuperDiploma.Restaurant.DataContext.EF.Models.ShopItem;
using SuperDiploma.Restaurant.DataContext.EF.Repositories;
using SuperDiploma.Restaurant.DataContext.Entities.Models;
using SuperDiploma.Restaurant.DomainService.Contracts;
using SuperDiploma.Restaurant.DomainService.Dto.Models;
using SuperDiploma.Restaurant.DomainService.Dto.Models.ShopItem;
using SuperDiploma.Restaurant.DomainService.Enums;

namespace SuperDiploma.Restaurant.DomainService;

public class ShopItemService : GenericShopItem<ShopItemDbo, ShopItemFormDto>, IShopItemService
{
    public ShopItemService(IRestaurantUnitOfWork myUnitOfWork, IAuthService authService, IMapper mapper)
        : base(myUnitOfWork, authService, mapper){ }

    public async Task<PaginatedResponseDto<IEnumerable<ShopItemListItemDto>>> GetFilteredListAsync(ShopItemGridFilterDto filter)
    {
        var filterDbo = Mapper.Map<ShopItemGridFilter>(filter);
        var dbo = await MyUnitOfWork.Repository<ShopItemDbo>().GetFilteredListAsync(filterDbo);
        return Mapper.Map<PaginatedResponseDto<IEnumerable<ShopItemListItemDto>>>(dbo);
    }

    public async Task<ShopItemFilterDatasourceDto> GetGridDataSourcesAsync()
    {
        var categories = await MyUnitOfWork.Repository<ShopItemCategoryDbo>().GetFilterDatasourceAsync();
        var states = Enum.GetValues(typeof(ShopItemState))
            .Cast<ShopItemState>()
            .Select(t => new DatasourceItemDto()
            {
                Id = ((int)t),
                Name = t.ToString(),
                Description = t.ToString(),
            });

        var result = new ShopItemFilterDatasourceDto
        {
            Categories = Mapper.Map<IEnumerable<DatasourceItemDto>>(categories),
            States = states
        };

        return result;
    }

    public async Task<ShopItemPreviewDto> GetPreviewByIdAsync(int id)
    {
        var dbo = await MyUnitOfWork.Repository<ShopItemDbo>().GetPreviewByIdAsync(id);
        return Mapper.Map<ShopItemPreviewDto>(dbo);
    }

    //public async Task<ShopItemFormDto> GetItemByIdAsync(int id)
    //{
    //    var dbo = await _myUnitOfWork.Repository<ShopItemDbo>().GetByIdAsync(id);
    //    return dbo == null ? null : _mapper.Map<ShopItemFormDto>(dbo);
    //}

    public async Task<ShopItemFormDatasourceDto> GetFormDataSourcesAsync()
    {
        var categories = await MyUnitOfWork.Repository<ShopItemCategoryDbo>().GetDatasourceAsync();
        var states = Enum.GetValues(typeof(ShopItemState))
            .Cast<ShopItemState>()
            .Select(t => new DatasourceItemDto()
            {
                Id = ((int)t),
                Name = t.ToString(),
                Description = t.ToString(),
            });

        var result = new ShopItemFormDatasourceDto
        {
            Categories = Mapper.Map<IEnumerable<DatasourceItemDto>>(categories),
            States = states
        };

        return result;
    }

    //public async Task<ShopItemFormDto> CreateOrUpdateItemAsync(ShopItemFormDto item)
    //{
    //    var isNew = item.Id == 0;
    //    var currentDateTime = DateTimeOffset.Now;

    //    var dbo = _mapper.Map<ShopItemDbo>(item);

    //    var currentUser = await _authService.GetCurrentUserIdAsync();

    //    dbo.ModifiedBy = currentUser;
    //    dbo.ModifiedAt = currentDateTime;

    //    if (isNew)
    //    {
    //        dbo.CreatedBy = currentUser;
    //        dbo.CreatedAt = currentDateTime;
    //        _myUnitOfWork.Repository<ShopItemDbo>().Insert(dbo);
    //    }
    //    else
    //    {
    //        var existedItem = await _myUnitOfWork.Repository<ShopItemDbo>().GetByIdAsync(dbo.Id);

    //        if (existedItem == null) throw new InvalidOperationException("Об'єкт не знайдений.");

    //        dbo.IsDeleted = existedItem.IsDeleted;
    //        dbo.CreatedBy = existedItem.CreatedBy;
    //        dbo.CreatedAt = existedItem.CreatedAt;

    //        _myUnitOfWork.Repository<ShopItemDbo>().Update(dbo);
    //    }

    //    await _myUnitOfWork.SaveChangesAsync();

    //    return await GetItemByIdAsync(dbo.Id);
    //}

    //public async Task<ShopItemFormDto> RemoveItemAsync(int id)
    //{
    //    var repository = _myUnitOfWork.Repository<ShopItemDbo>();   
    //    var existingItem = await repository.GetByIdAsync(id);

    //    if (existingItem == null)
    //    {
    //        throw new InvalidOperationException("Об'єкт не знайдений.");
    //    }

    //    existingItem.IsDeleted = true;
    //    existingItem.ModifiedAt = DateTimeOffset.Now;
    //    existingItem.ModifiedBy = await _authService.GetCurrentUserIdAsync();

    //    repository.Update(existingItem);
    //    await _myUnitOfWork.SaveChangesAsync();

    //    return _mapper.Map<ShopItemFormDto>(existingItem);
    //}

}