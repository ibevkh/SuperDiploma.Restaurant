using AutoMapper;
using SuperDiploma.Restaurant.DataContext.Entities.Models;
using SuperDiploma.Restaurant.DomainService.Dto.Models;

namespace SuperDiploma.Restaurant.DomainService.Dto.Mappings;

public class RestaurantMapping : Profile
{
    public RestaurantMapping()
    {
        CreateMap<CategoryDbo, CategoryDto>().ReverseMap();

        CreateMap<DishMenuItemDbo, DishMenuItemDto>().ReverseMap();

        //CreateMap<OrderItemDbo, OrderItemDto>().ReverseMap();

        //CreateMap<OrderDbo, OrderDto>().ReverseMap();

        CreateMap<ReservationDbo, ReservationDto>().ReverseMap();

        //CreateMap<CustomerDbo, CustomerDto>().ReverseMap();
    }
}