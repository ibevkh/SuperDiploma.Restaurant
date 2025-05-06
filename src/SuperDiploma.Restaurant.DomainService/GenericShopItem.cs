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
    protected readonly IRestaurantUnitOfWork MyUnitOfWork;
    protected readonly IAuthService AuthService;
    protected readonly IMapper Mapper;

    public GenericShopItem (IRestaurantUnitOfWork myUnitOfWork, IAuthService authService, IMapper mapper)
    {
        MyUnitOfWork = myUnitOfWork;
        AuthService = authService;
        Mapper = mapper;
    }

    public async Task<TDto> GetItemByIdAsync(int id)
    {
        var dbo = await MyUnitOfWork.Repository<TDbo>().GetByIdAsync(id);
        return dbo == null ? null : Mapper.Map<TDto>(dbo);
    }

    public async Task<TDto> CreateOrUpdateItemAsync(TDto dto)
    {
        var dbo = Mapper.Map<TDbo>(dto);

        var isNew = dbo.Id == 0;
        var currentDateTime = DateTimeOffset.Now;

        var currentUser = await AuthService.GetCurrentUserIdAsync();

        dbo.ModifiedBy = currentUser;
        dbo.ModifiedAt = currentDateTime;

        var repository = MyUnitOfWork.Repository<TDbo>();

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

        await MyUnitOfWork.SaveChangesAsync();

        return await GetItemByIdAsync(dbo.Id);
    }

    public async Task<TDto> RemoveItemAsync(int id)
    {
        var repository = MyUnitOfWork.Repository<TDbo>();
        var existingItem = await repository.GetByIdAsync(id);

        if (existingItem == null)
        {
            throw new InvalidOperationException("Об'єкт не знайдений.");
        }

        existingItem.IsDeleted = true;
        existingItem.ModifiedAt = DateTimeOffset.Now;
        existingItem.ModifiedBy = await AuthService.GetCurrentUserIdAsync();

        repository.Update(existingItem);
        await MyUnitOfWork.SaveChangesAsync();

        return Mapper.Map<TDto>(existingItem);
    }
}