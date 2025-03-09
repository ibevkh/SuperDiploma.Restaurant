using AutoMapper;
using SuperDiploma.Restaurant.DataContext.EF;
using SuperDiploma.Restaurant.DataContext.EF.Repositories;
using SuperDiploma.Restaurant.DataContext.Entities.Models;
using SuperDiploma.Restaurant.DomainService.Contracts;
using SuperDiploma.Restaurant.DomainService.Dto.Models;

namespace SuperDiploma.Restaurant.DomainService;

internal class DishService : IDishService
{
    private readonly IMapper _mapper;
    private readonly IRestaurantUnitOfWork _myUnitOfWork;

    public DishService(IRestaurantUnitOfWork myUnitOfWork, IMapper mapper)
    {
        _myUnitOfWork = myUnitOfWork;
        _mapper = mapper;
    }

    public async Task<DishMenuItemDto> AddCategoryAsync(DishMenuItemDto dishDto)
    {
        var dishForAdd = _mapper.Map<DishMenuItemDbo>(dishDto);
        _myUnitOfWork.Repository<DishMenuItemDbo>().Insert(dishForAdd);
        await _myUnitOfWork.SaveChangesAsync();

        return _mapper.Map<DishMenuItemDto>(dishForAdd);
    }

    public async Task<DishMenuItemDto> UpdateCategoryAsync(DishMenuItemDto dishDto)
    {
        var dishForUpdate = _mapper.Map<DishMenuItemDbo>(dishDto);
        _myUnitOfWork.Repository<DishMenuItemDbo>().Update(dishForUpdate);
        await _myUnitOfWork.SaveChangesAsync();

        return _mapper.Map<DishMenuItemDto>(dishForUpdate);
    }

    public async Task DeleteCategoryAsync(int id)
    {
        var dishForRemove = await _myUnitOfWork.Repository<DishMenuItemDbo>().FindAsync(id);
        if (dishForRemove != null)
        {
            await _myUnitOfWork.Repository<CategoryDbo>().DeleteAsync(dishForRemove);
            await _myUnitOfWork.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<DishMenuItemDto>> GetDishMenuItemByCategory(int categoryId)
    {
        var dishes = await _myUnitOfWork.Repository<DishMenuItemDbo>().GetDishMenuItemByCategory(categoryId);

        return _mapper.Map<IEnumerable<DishMenuItemDto>>(dishes);
    }
}