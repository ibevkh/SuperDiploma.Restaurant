using AutoMapper;
using SuperDiploma.Restaurant.DataContext.EF;
using SuperDiploma.Restaurant.DataContext.Entities.Models;
using SuperDiploma.Restaurant.DomainService.Dto.Models.Order;

namespace SuperDiploma.Restaurant.DomainService;

public class OrderRequestService : IOrderRequestService
{
    private readonly IRestaurantUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderRequestService(IRestaurantUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OrderRequestDto> AddOrderAsync(OrderRequestDto orderRequestDto)
    {
        var orderRequest = _mapper.Map<OrderDbo>(orderRequestDto);
        orderRequest.CreatedAt = DateTimeOffset.Now;
        orderRequest.ModifiedAt = DateTimeOffset.Now;

        _unitOfWork.Repository<OrderDbo>().Insert(orderRequest);

        await _unitOfWork.SaveChangesAsync();

        foreach (var item in orderRequestDto.Items)
        {
            _unitOfWork.TempRepository<OrderItemDbo>().Insert(new OrderItemDbo
            {
                OrderId = orderRequest.Id,
                Quantity = item.Quantity,
                ShopItemId = item.ShopItemId,
            });
        }

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<OrderRequestDto>(orderRequest);
    }
}