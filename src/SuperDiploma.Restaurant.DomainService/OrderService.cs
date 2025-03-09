using AutoMapper;
using SuperDiploma.Restaurant.DataContext.EF;
using SuperDiploma.Restaurant.DataContext.EF.Repositories;
using SuperDiploma.Restaurant.DataContext.Entities.Models;
using SuperDiploma.Restaurant.DomainService.Contracts;
using SuperDiploma.Restaurant.DomainService.Dto.Models;

namespace SuperDiploma.Restaurant.DomainService;

public class OrderService : IOrderService
{
    private readonly IMapper _mapper;
    private readonly IRestaurantUnitOfWork _myUnitOfWork;
    public OrderService(IMapper mapper, IRestaurantUnitOfWork myUnitOfWork)
    {
        _mapper = mapper;
        _myUnitOfWork = myUnitOfWork;
    }

    //public async Task<OrderDto> AddOrderAsync(OrderDto orderDto)
    //{
    //    var orderForAdd = _mapper.Map<OrderDbo>(orderDto);
    //    _myUnitOfWork.Repository<OrderDbo>().Insert(orderForAdd);
    //    await _myUnitOfWork.SaveChangesAsync();

    //    return _mapper.Map<OrderDto>(orderForAdd);
    //}

    //public async Task<IEnumerable<OrderDto>> GetOrderAsync()
    //{
    //    var orders = await _myUnitOfWork.Repository<OrderDbo>().GetAllAsync();
    //    return _mapper.Map<IEnumerable<OrderDto>>(orders);
    //}
    public Task<OrderDto> AddOrderAsync(OrderDto orderDto)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<OrderDto>> GetOrderAsync()
    {
        var dbo = await _myUnitOfWork.Repository<OrderDbo>().GetOrderWithDetails();

        return _mapper.Map<IEnumerable<OrderDto>>(dbo);
    }
}