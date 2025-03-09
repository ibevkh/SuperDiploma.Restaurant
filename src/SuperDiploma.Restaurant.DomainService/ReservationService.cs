using AutoMapper;
using SuperDiploma.Restaurant.DataContext.EF;
using SuperDiploma.Restaurant.DataContext.Entities.Models;
using SuperDiploma.Restaurant.DomainService.Contracts;
using SuperDiploma.Restaurant.DomainService.Dto.Models;

namespace SuperDiploma.Restaurant.DomainService;

internal class ReservationService : IReservationService
{
    private readonly IMapper _mapper;
    private readonly IRestaurantUnitOfWork _myUnitOfWork;

    public ReservationService(IRestaurantUnitOfWork myUnitOfWork, IMapper mapper)
    {
        _myUnitOfWork = myUnitOfWork;
        _mapper = mapper;
    }

    public async Task<ReservationDto> AddReservationAsync(ReservationDto reservationDto)
    {
        var reservationForAdd = _mapper.Map<ReservationDbo>(reservationDto);
        _myUnitOfWork.Repository<ReservationDbo>().Insert(reservationForAdd);
        await _myUnitOfWork.SaveChangesAsync();

        return _mapper.Map<ReservationDto>(reservationForAdd);
    }

    public async Task<IEnumerable<ReservationDto>> GetReservationAsync()
    {
        var reservations= await _myUnitOfWork.Repository<ReservationDbo>().GetAllAsync();
        return _mapper.Map<IEnumerable<ReservationDto>>(reservations);
    }
}