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

public class ShopItemService : IShopItemService
{
    private readonly IRestaurantUnitOfWork _myUnitOfWork;
    private readonly IMapper _mapper;

    public ShopItemService(IRestaurantUnitOfWork myUnitOfWork, IMapper mapper)
    {
        _myUnitOfWork = myUnitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ShopItemListItemDto>> GetFilteredListAsync(ShopItemGridFilterDto filter)
    {
        var filterDbo = _mapper.Map<ShopItemGridFilter>(filter);
        var dbo = await _myUnitOfWork.Repository<ShopItemDbo>().GetFilteredListAsync(filterDbo);
        return _mapper.Map<IEnumerable<ShopItemListItemDto>>(dbo);
    }

    public async Task<ShopItemFilterDatasourceDto> GetFilterDataSourcesAsync()
    {
        var categories = await _myUnitOfWork.Repository<ShopItemCategoryDbo>().GetFilterDatasourceAsync();
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
            Categories = _mapper.Map<IEnumerable<DatasourceItemDto>>(categories),
            States = states
        };

        return result;
    }

    public async Task<ShopItemPreviewDto> GetPreviewByIdAsync(int id)
    {
        var dbo = await _myUnitOfWork.Repository<ShopItemDbo>().GetPreviewByIdAsync(id);
        return _mapper.Map<ShopItemPreviewDto>(dbo);
    }

    public async Task<ShopItemFormDto> GetByIdAsync(int id)
    {
        var dbo = await _myUnitOfWork.Repository<ShopItemDbo>().GetByIdAsync(id);
        return _mapper.Map<ShopItemFormDto>(dbo);
    }

    public async Task<ShopItemFormDatasourceDto> GetFormDataSourcesAsync()
    {
        var categories = await _myUnitOfWork.Repository<ShopItemCategoryDbo>().GetDatasourceAsync();
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
            Categories = _mapper.Map<IEnumerable<DatasourceItemDto>>(categories),
            States = states
        };

        return result;
    }
}