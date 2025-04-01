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

    public ShopItemsController(IShopItemService shopItemService)
    {
        _shopItemService = shopItemService;
    }


    [HttpPost("filtered-grid")]
    public async Task<ActionResult<PaginatedResponseDto<IEnumerable<ShopItemListItemDto>>>> GetFilteredList(ShopItemGridFilterDto filter)
    {
        var result = await _shopItemService.GetFilteredListAsync(filter);
        return Ok(result);
    }

    [HttpGet("filter-datasources")]
    public async Task<ActionResult<ShopItemFilterDatasourceDto>> GetFilterDataSources()
    {
        var result = await _shopItemService.GetFilterDataSourcesAsync();
        return Ok(result);
    }

    [HttpGet("preview/{id:int}")]
    public async Task<ActionResult<ShopItemPreviewDto>> GetPreviewById(int id)
    {
        var result = await _shopItemService.GetPreviewByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ShopItemFormDto>> GetById(int id)
    {
        var result = await _shopItemService.GetByIdAsync(id);
        return result != null ? Ok(result) : NotFound();
    }

    [HttpGet("form-datasources")]
    public async Task<ActionResult<ShopItemFormDatasourceDto>> GetFormDataSources()
    {
        var result = await _shopItemService.GetFormDataSourcesAsync();
        return Ok(result);
    }
}