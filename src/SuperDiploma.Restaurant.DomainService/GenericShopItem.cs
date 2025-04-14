using AutoMapper;
using SuperDiploma.Core.Models;
using SuperDiploma.Restaurant.DataContext.EF;
using SuperDiploma.Restaurant.DataContext.Entities.Models;
using SuperDiploma.Restaurant.DomainService.Contracts;
using SuperDiploma.Restaurant.DomainService.Dto.Models;

namespace SuperDiploma.Restaurant.DomainService;

public class GenericShopItem<TDbo, TDto> : IGenericShopItem<TDbo, TDto>
    where TDbo : SuperDiplomaBaseDbo
    where TDto : class
{
    private readonly IRestaurantUnitOfWork _myUnitOfWork;
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public GenericShopItem (IRestaurantUnitOfWork myUnitOfWork, IAuthService authService, IMapper mapper)
    {
        _myUnitOfWork = myUnitOfWork;
        _authService = authService;
        _mapper = mapper;
    }

    public async Task<TDto> GetItemByIdAsync(int id)
    {
        var dbo = await _myUnitOfWork.Repository<TDbo>().GetByIdAsync(id);
        return dbo == null ? null : _mapper.Map<TDto>(dbo);
    }

    public async Task<TDto> CreateOrUpdateItemAsync(TDto dto)
    {
        var dbo = _mapper.Map<TDbo>(dto);

        var isNew = dbo.Id == 0;
        var currentDateTime = DateTimeOffset.Now;

        var currentUser = await _authService.GetCurrentUserIdAsync();

        dbo.ModifiedBy = currentUser;
        dbo.ModifiedAt = currentDateTime;

        var repository = _myUnitOfWork.Repository<TDbo>();

        if (isNew)
        {
            dbo.CreatedBy = currentUser;
            dbo.CreatedAt = currentDateTime;
            repository.Insert(dbo);
        }
        else
        {
            var existedItem = await repository.GetByIdAsync(dbo.Id);

            if (existedItem == null) throw new InvalidOperationException("Об'єкт не знайдений.");

            dbo.IsDeleted = existedItem.IsDeleted;
            dbo.CreatedBy = existedItem.CreatedBy;
            dbo.CreatedAt = existedItem.CreatedAt;

            repository.Update(dbo);
        }

        await _myUnitOfWork.SaveChangesAsync();

        return await GetItemByIdAsync(dbo.Id);
    }

    public async Task<TDto> RemoveItemAsync(int id)
    {
        var repository = _myUnitOfWork.Repository<TDbo>();
        var existingItem = await repository.GetByIdAsync(id);

        if (existingItem == null)
        {
            throw new InvalidOperationException("Об'єкт не знайдений.");
        }

        existingItem.IsDeleted = true;
        existingItem.ModifiedAt = DateTimeOffset.Now;
        existingItem.ModifiedBy = await _authService.GetCurrentUserIdAsync();

        repository.Update(existingItem);
        await _myUnitOfWork.SaveChangesAsync();

        return _mapper.Map<TDto>(existingItem);
    }
}