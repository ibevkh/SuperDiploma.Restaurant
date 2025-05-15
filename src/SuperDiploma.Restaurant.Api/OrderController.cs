using Microsoft.AspNetCore.Mvc;
using SuperDiploma.Restaurant.DomainService;
using SuperDiploma.Restaurant.DomainService.Contracts;
using SuperDiploma.Restaurant.DomainService.Dto.Models.CategoryShopItem;
using SuperDiploma.Restaurant.DomainService.Dto.Models;
using SuperDiploma.Restaurant.DomainService.Dto.Models.Order;

namespace SuperDiploma.Restaurant.Api;

[ApiController]
[Route("api/order")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost("review")]
    public async Task<ActionResult<PaginatedResponseDto<IEnumerable<OrderGridDto>>>> GetListAsync(
        [FromBody] OrderGridFilterDto filter)
    {
        var result = await _orderService.GetListAsync(filter);
        return Ok(result);
    }

    [HttpPost("request")]
    public async Task<ActionResult<OrderRequestDto>> AddaOrder(OrderRequestDto orderRequest)
    {
        var result = await _orderService.AddOrderAsync(orderRequest);
        return Ok(result);
    }
}