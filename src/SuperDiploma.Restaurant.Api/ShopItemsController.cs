using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using SuperDiploma.Restaurant.DomainService.Contracts;
using SuperDiploma.Restaurant.DomainService.Dto.Models;
using SuperDiploma.Restaurant.DomainService.Dto.Models.ShopItem;

namespace SuperDiploma.Restaurant.Api;

[ApiController]
[Route("api/shop-items")]
public class ShopItemsController : ControllerBase
{
    private readonly IShopItemService _shopItemService;
    private readonly IValidator<ShopItemFormDto> _validator;

    public ShopItemsController(IShopItemService shopItemService, IValidator<ShopItemFormDto> validator)
    {
        _shopItemService = shopItemService;
        _validator = validator;
    }


    [HttpPost("filtered-grid")]
    public async Task<ActionResult<PaginatedResponseDto<IEnumerable<ShopItemListItemDto>>>> GetFilteredGrid(
        ShopItemGridFilterDto filter)
    {
        var result = await _shopItemService.GetFilteredListAsync(filter);
        return Ok(result);
    }

    [HttpGet("grid-datasources")]
    public async Task<ActionResult<ShopItemFilterDatasourceDto>> GetGridDataSources()
    {
        var result = await _shopItemService.GetGridDataSourcesAsync();
        return Ok(result);
    }

    [HttpGet("preview/{id:int}")]
    public async Task<ActionResult<ShopItemPreviewDto>> GetPreviewById(int id)
    {
        var result = await _shopItemService.GetPreviewByIdAsync(id);
        return  result != null ? Ok(result) : NotFound();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ShopItemFormDto>> GetItemById(int id)
    {
        var result = await _shopItemService.GetItemByIdAsync(id);
        return result != null ? Ok(result) : NotFound();
    }

    [HttpGet("form-datasources")]
    public async Task<ActionResult<ShopItemFormDatasourceDto>> GetFormDataSources()
    {
        var result = await _shopItemService.GetFormDataSourcesAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ShopItemFormDto>> CreateOrUpdateItem([FromBody] [CustomizeValidator(RuleSet = "create")] ShopItemFormDto item)
    {
        var result = await _shopItemService.CreateOrUpdateItemAsync(item);
        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ShopItemFormDto>> RemoveItem(int id)
    {
        var result = await _shopItemService.RemoveItemAsync(id);
        return Ok(result);
    }
}