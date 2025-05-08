using SuperDiploma.Restaurant.DomainService.Dto.Models.ShopItem;
using SuperDiploma.Restaurant.DomainService.Dto.Models;
using AutoMapper;
using SuperDiploma.Restaurant.DataContext.EF;
using SuperDiploma.Restaurant.DomainService.Contracts;
using SuperDiploma.Restaurant.DataContext.EF.Models;
using SuperDiploma.Restaurant.DataContext.EF.Repositories;
using SuperDiploma.Restaurant.DataContext.Entities.Models;

namespace SuperDiploma.Restaurant.DomainService;

public class RestaurantMenuCardService: IRestaurantMenuCardService
{
    private readonly IRestaurantUnitOfWork _myUnitOfWork;
    private readonly IMapper _mapper;

    public RestaurantMenuCardService(IRestaurantUnitOfWork myUnitOfWork, IMapper mapper)
    {
        _myUnitOfWork = myUnitOfWork;
        _mapper = mapper;
    }

    public async Task<PaginatedResponseDto<IEnumerable<RestaurantMenuCardDto>>> GetFilteredCardAsync(RestaurantMenuCardFilterDto filter)
    {
        var filterDbo = _mapper.Map<RestaurantMenuCardFilter>(filter);

        // 2. Отримання відфільтрованого списку з бази даних
        var paginatedMenuCards = await _myUnitOfWork
            .Repository<ShopItemDbo>()
            .GetFilteredCardAsync(filterDbo);

        // 3. Мапінг результату в DTO-об'єкт
        var result = _mapper.Map<PaginatedResponseDto<IEnumerable<RestaurantMenuCardDto>>>(paginatedMenuCards);

        return result;
    }
}