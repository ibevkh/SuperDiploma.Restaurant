using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using SuperDiploma.Restaurant.DomainService;
using SuperDiploma.Restaurant.DomainService.Contracts;
using SuperDiploma.Restaurant.DomainService.Dto.Models;
using SuperDiploma.Restaurant.DomainService.Dto.Models.CategoryShopItem;
using SuperDiploma.Restaurant.DomainService.Dto.Models.ShopItem;

namespace SuperDiploma.Restaurant.Api;

[ApiController]
[Route("api/shop-items-category")]
public class ShopItemCategoryController : ControllerBase
{
    private readonly IShopItemCategoryService _categoryService;

    public ShopItemCategoryController(IShopItemCategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost("list")]
    public async Task<ActionResult<PaginatedResponseDto<IEnumerable<ShopItemCategoryGridDto>>>> GetListAsync(
        [FromBody] ShopItemCategoryGridFilterDto filter)
    {
        var result = await _categoryService.GetListAsync(filter);
        return Ok(result);
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<ShopItemCategoryFormDto>> GetCategoryById(int id)
    {
        var result = await _categoryService.GetItemByIdAsync(id);
        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<ShopItemCategoryFormDto>> CreateOrUpdateCategory(ShopItemCategoryFormDto category)
    {
        var result = await _categoryService.CreateOrUpdateItemAsync(category);
        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ShopItemFormDto>> RemoveCategory(int id)
    {
        var result = await _categoryService.RemoveItemAsync(id);
        return Ok(result);
    }
}