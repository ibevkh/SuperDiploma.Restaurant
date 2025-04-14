using AutoMapper;
using SuperDiploma.Restaurant.DataContext.EF;
using SuperDiploma.Restaurant.DataContext.Entities.Models;
using SuperDiploma.Restaurant.DomainService.Contracts;
using SuperDiploma.Restaurant.DomainService.Dto.Models;

namespace SuperDiploma.Restaurant.DomainService;

public class CategoryService : ICategoryService
{
    // CRUD ОПЕРАЦІЇ ЗАСТОСОВУВАТИСЯ НЕ БУДУТЬ!!!
    //private readonly IMapper _mapper;
    //private readonly IRestaurantUnitOfWork _myUnitOfWork;

    //public CategoryService(IRestaurantUnitOfWork myUnitOfWork, IMapper mapper)
    //{
    //    _myUnitOfWork = myUnitOfWork;
    //    _mapper = mapper;
    //}

    //public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
    //{
    //    var categories = await _myUnitOfWork.Repository<CategoryDbo>().GetAllAsync();
    //    return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    //}

    //public async Task<CategoryDto> AddCategoryAsync(CategoryDto categoryDto)
    //{
    //    var categoryForAdd = _mapper.Map<CategoryDbo>(categoryDto);
    //    _myUnitOfWork.Repository<CategoryDbo>().Insert(categoryForAdd);
    //    await _myUnitOfWork.SaveChangesAsync();

    //    return _mapper.Map<CategoryDto>(categoryForAdd);
    //}

    //public async Task<CategoryDto> UpdateCategoryAsync(CategoryDto categoryDto)
    //{
    //    var categoryForUpdate = _mapper.Map<CategoryDbo>(categoryDto);
    //    _myUnitOfWork.Repository<CategoryDbo>().Update(categoryForUpdate);
    //    await _myUnitOfWork.SaveChangesAsync();

    //    return _mapper.Map<CategoryDto>(categoryForUpdate);
    //}

    //public async Task DeleteCategoryAsync(int id)
    //{
    //    var categoryForRemove= await _myUnitOfWork.Repository<CategoryDbo>().FindAsync(id);
    //    if (categoryForRemove != null)
    //    {
    //        await _myUnitOfWork.Repository<CategoryDbo>().DeleteAsync(categoryForRemove);
    //        await _myUnitOfWork.SaveChangesAsync();
    //    }
    //}

    //public Task<CategoryDto> AddCategoryAsync(CategoryDto categoryDto)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<CategoryDto> UpdateCategoryAsync(CategoryDto categoryDto)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task DeleteCategoryAsync(int id)
    //{
    //    throw new NotImplementedException();
    //}
}