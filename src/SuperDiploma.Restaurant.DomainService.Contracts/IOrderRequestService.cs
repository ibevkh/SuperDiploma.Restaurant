using SuperDiploma.Restaurant.DomainService.Dto.Models.Order;

namespace SuperDiploma.Restaurant.DomainService;

public interface IOrderRequestService
{
    public Task<OrderRequestDto> AddOrderAsync(OrderRequestDto dto);
}