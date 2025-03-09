using Microsoft.AspNetCore.Mvc;
using SuperDiploma.Restaurant.DomainService.Contracts;
using SuperDiploma.Restaurant.DomainService.Dto.Models;

namespace SuperDiploma.Restaurant.Api;

[ApiController]
[Route("api/categories")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
    {
        return Ok(await _categoryService.GetAllCategoriesAsync());
    }

    //[HttpPost]
    //public async Task<ActionResult<CategoryDto>> AddTask(CategoryDto dto)
    //{
    //    return Ok(await _categoryService.AddCategoryAsync(dto));
    //}

    //[HttpDelete]
    //public async Task<ActionResult<CategoryDto>> DeleteTask(int id)
    //{
    //    await _categoryService.DeleteCategoryAsync(id);
    //    return Ok();
    //}

    //[HttpPut]
    //public async Task<ActionResult<CategoryDto>> UpdateTask(CategoryDto dto)
    //{
    //    return Ok(await _categoryService.UpdateCategoryAsync(dto));
    //}
}