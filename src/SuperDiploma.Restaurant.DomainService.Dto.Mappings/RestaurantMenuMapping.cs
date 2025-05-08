using AutoMapper;
using SuperDiploma.Restaurant.DataContext.EF.Models;
using SuperDiploma.Restaurant.DataContext.Entities.Models;
using SuperDiploma.Restaurant.DomainService.Dto.Models;

namespace SuperDiploma.Restaurant.DomainService.Dto.Mappings;

public class RestaurantMenuMapping : Profile
{
    public RestaurantMenuMapping()
    {
        // 1. FilterDto -> Filter
        CreateMap<RestaurantMenuCardFilterDto, RestaurantMenuCardFilter>().ReverseMap();

        // 2. Dbo -> DTO
        CreateMap<ShopItemDbo, RestaurantMenuCardDto>().ReverseMap();
    }
}