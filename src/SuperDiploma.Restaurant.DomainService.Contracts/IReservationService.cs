using SuperDiploma.Restaurant.DomainService.Dto.Models;

namespace SuperDiploma.Restaurant.DomainService.Contracts;

public interface IReservationService
{
    Task<ReservationDto> AddReservationAsync(ReservationDto reservationDto);
}