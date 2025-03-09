using Microsoft.AspNetCore.Mvc;
using SuperDiploma.Restaurant.DomainService.Contracts;
using SuperDiploma.Restaurant.DomainService.Dto.Models;

namespace SuperDiploma.Restaurant.Api;

[ApiController]
[Route("api/orderERROR")]
internal class ReservationController : ControllerBase
{
    private readonly IReservationService _reservationService;
    public ReservationController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReservationDto>>> GetAll()
    {
        //return Ok(await _reservationService.GetOrderAsync());
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<ActionResult<ReservationDto>> AddTask(ReservationDto dto)
    {
        return Ok(await _reservationService.AddReservationAsync(dto));
    }

}