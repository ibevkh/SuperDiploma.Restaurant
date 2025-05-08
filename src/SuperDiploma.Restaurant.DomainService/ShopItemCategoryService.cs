using AutoMapper;
using SuperDiploma.Restaurant.DataContext.EF;
using SuperDiploma.Restaurant.DataContext.EF.Models;
using SuperDiploma.Restaurant.DataContext.EF.Repositories;
using SuperDiploma.Restaurant.DataContext.Entities.Models;
using SuperDiploma.Restaurant.DomainService.Contracts;
using SuperDiploma.Restaurant.DomainService.Dto.Models;

namespace SuperDiploma.Restaurant.DomainService;

public class ShopItemCategoryService
    : GenericService<ShopItemCategoryDbo, ShopItemCategoryFormDto>, IShopItemCategoryService
{
    public ShopItemCategoryService(IRestaurantUnitOfWork myUnitOfWork, IAuthService authService, IMapper mapper)
        : base(myUnitOfWork, authService, mapper) { }

    public async Task<PaginatedResponseDto<IEnumerable<ShopItemCategoryGridDto>>> GetListAsync(ShopItemCategoryGridFilterDto filter)
    {
        var filterDbo = Mapper.Map<ShopItemCategoryGridFilter>(filter);

        var paginatedCategories = await MyUnitOfWork
            .Repository<ShopItemCategoryDbo>()
            .GetFilteredListAsync(filterDbo);

        var result = Mapper.Map<PaginatedResponseDto<IEnumerable<ShopItemCategoryGridDto>>>(paginatedCategories);

        return result;
    }
}