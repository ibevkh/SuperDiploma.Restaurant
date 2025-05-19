using AutoMapper;
using SuperDiploma.Restaurant.DataContext.EF.Models;
using SuperDiploma.Restaurant.DataContext.Entities.Models;
using SuperDiploma.Restaurant.DomainService.Dto.Models;
using SuperDiploma.Restaurant.DomainService.Dto.Models.Order;

namespace SuperDiploma.Restaurant.DomainService.Dto.Mappings;

public class OrderMapping : Profile
{
    public OrderMapping()
    {
        CreateMap<OrderGridFilterDto, OrderGridFilter>();

        CreateMap<OrderDbo, OrderGridDto>()
            //.ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
            //.ForMember(dest => dest.CustomerPhoneNumber, opt => opt.MapFrom(src => src.Customer.PhoneNumber))
            //.ForMember(dest => dest.CustomerAddress, opt => opt.MapFrom(src => src.Customer.Address))
            //.ForMember(dest => dest.Entrance, opt => opt.MapFrom(src => src.Customer.Entrance))
            //.ForMember(dest => dest.ApartmentNumber, opt => opt.MapFrom(src => src.Customer.ApartmentNumber))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems))
            //.ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
            ;

        CreateMap<OrderItemDbo, OrderItemGridDto>()
            .ForMember(dest => dest.ShopItemId, opt => opt.MapFrom(src => src.ShopItemId))
            .ForMember(dest => dest.ShopItemName, opt => opt.MapFrom(src => src.ShopItem.Name))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

        CreateMap<OrderRequestDto, OrderDbo>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
            .ForMember(dest => dest.CustomerPhoneNumber, opt => opt.MapFrom(src => src.CustomerPhoneNumber))
            .ForMember(dest => dest.DeliveryAddress, opt => opt.MapFrom(src => src.DeliveryAddress))
            .ForMember(dest => dest.CustomerId, opt => opt.Ignore()) // Мапимо CustomerId
            .ForMember(dest => dest.DeliveryTime, opt => opt.MapFrom(src => src.DeliveryTime))
            //.ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.Items)) // Мапимо OrderItems
            .ForMember(dest => dest.OrderItems, opt => opt.Ignore())
            .ForMember(dest => dest.Customer, opt => opt.Ignore()) // Ігноруємо Customer, бо передаємо лише CustomerId
            ;

        CreateMap<OrderDbo, OrderRequestDto>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems));

        CreateMap<OrderItemGridDto, OrderItemDbo>()
            .ForMember(dest => dest.ShopItemId, opt => opt.MapFrom(src => src.ShopItemId))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ReverseMap();

        
    }
}