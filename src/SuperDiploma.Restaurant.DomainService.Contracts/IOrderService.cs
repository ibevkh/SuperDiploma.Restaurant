using SuperDiploma.Restaurant.DomainService.Dto.Models.Order;
using SuperDiploma.Restaurant.DomainService.Dto.Models;

namespace SuperDiploma.Restaurant.DomainService;

public interface IOrderService
{
    Task<PaginatedResponseDto<IEnumerable<OrderGridDto>>> GetListAsync(OrderGridFilterDto filter);
    Task<OrderRequestDto> AddOrderAsync(OrderRequestDto orderRequestDto);
}