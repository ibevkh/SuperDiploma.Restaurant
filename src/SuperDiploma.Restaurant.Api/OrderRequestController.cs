using Microsoft.AspNetCore.Mvc;
using SuperDiploma.Restaurant.DomainService;
using SuperDiploma.Restaurant.DomainService.Dto.Models.Order;

namespace SuperDiploma.Restaurant.Api;

[ApiController]
[Route("api/order-request")]
public class OrderRequestController : ControllerBase
{
    private readonly IOrderRequestService _orderRequestService;

    public OrderRequestController(IOrderRequestService orderRequestService)
    {
        _orderRequestService = orderRequestService;
    }

    [HttpPost]
    public async Task<ActionResult<OrderRequestDto>> AddaOrder (OrderRequestDto orderRequest)
    {
        var result = await _orderRequestService.AddOrderAsync(orderRequest);
        return Ok(result);
    }
}