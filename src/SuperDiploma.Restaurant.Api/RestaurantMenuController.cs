using Microsoft.AspNetCore.Mvc;
using SuperDiploma.Restaurant.DomainService;
using SuperDiploma.Restaurant.DomainService.Contracts;
using SuperDiploma.Restaurant.DomainService.Dto.Models;
using SuperDiploma.Restaurant.DomainService.Dto.Models.RestaurantMenu;

namespace SuperDiploma.Restaurant.Api;

[ApiController]
[Route("api/restaurant-menu")]
public class RestaurantMenuController : ControllerBase
{
    private readonly IRestaurantMenuService _restaurantMenuService;

    public RestaurantMenuController(IRestaurantMenuService restaurantMenuService)
    {
        _restaurantMenuService = restaurantMenuService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RestaurantMenuCategoryItemDto>>> GetRestaurantMenuAsync()
    {
        var result = await _restaurantMenuService.GetRestaurantMenu();
        return Ok(result);
    }
}