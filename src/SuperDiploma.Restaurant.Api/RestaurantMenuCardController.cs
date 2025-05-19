using Microsoft.AspNetCore.Mvc;
using SuperDiploma.Restaurant.DomainService.Contracts;
using SuperDiploma.Restaurant.DomainService.Dto.Models;

namespace SuperDiploma.Restaurant.Api;

[ApiController]
[Route("api/restaurant-menu-card")]
public class RestaurantMenuCardController : ControllerBase
{
    private readonly IRestaurantMenuCardService _restaurantMenuCardService;

    public RestaurantMenuCardController(IRestaurantMenuCardService restaurantMenuCardService)
    {
        _restaurantMenuCardService = restaurantMenuCardService;
    }

    //[HttpPost("list")]
    //public async Task<ActionResult<PaginatedResponseDto<IEnumerable<RestaurantMenuCardDto>>>> GetListAsync(
    //    [FromBody] RestaurantMenuCardFilterDto filter)
    //{
    //    var result = await _restaurantMenuCardService.GetFilteredCardAsync(filter);
    //    return Ok(result);
    //}
}