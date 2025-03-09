using Microsoft.AspNetCore.Mvc;
using SuperDiploma.Restaurant.DomainService.Contracts;
using SuperDiploma.Restaurant.DomainService.Dto.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace SuperDiploma.Restaurant.Api;

[ApiController]
[Route("api/v1/order")]
[SwaggerTag("asd")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll()
    {
        return Ok(await _orderService.GetOrderAsync());
    }

    [HttpPost]
    public async Task<ActionResult<OrderDto>> AddTask(OrderDto dto)
    {
        return Ok(await _orderService.AddOrderAsync(dto));
    }

    [HttpGet("withDetails")]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllWithDetails()
    {
        return Ok(await _orderService.GetOrderAsync());
    }
}