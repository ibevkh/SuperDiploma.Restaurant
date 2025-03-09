using Microsoft.AspNetCore.Mvc;
using SuperDiploma.Restaurant.DomainService.Contracts;
using SuperDiploma.Restaurant.DomainService.Dto.Models;

namespace SuperDiploma.Restaurant.Api;

[ApiController]
[Route("api/category/dishes")]
internal class DishController : ControllerBase
{
    private readonly IDishService _dishService;

    public DishController(IDishService dishService)
    {
        _dishService = dishService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DishMenuItemDto>>> GetDishMenuItemByCategory(int categoryId)
    {
        var dishes = await _dishService.GetDishMenuItemByCategory(categoryId);
        return Ok(dishes);
    }

    [HttpPost]
    public async Task<ActionResult<DishMenuItemDto>> AddTask(DishMenuItemDto dto)
    {
        return Ok(await _dishService.AddCategoryAsync(dto));
    }

    [HttpDelete]
    public async Task<ActionResult<DishMenuItemDto>> DeleteTask(int id)
    {
        await _dishService.DeleteCategoryAsync(id);
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult<DishMenuItemDto>> UpdateTask(DishMenuItemDto dto)
    {
        return Ok(await _dishService.UpdateCategoryAsync(dto));
    }
}