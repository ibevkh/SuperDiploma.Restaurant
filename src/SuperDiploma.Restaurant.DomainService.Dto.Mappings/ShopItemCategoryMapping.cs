using AutoMapper;
using SuperDiploma.Restaurant.DataContext.Entities.Models;
using SuperDiploma.Restaurant.DomainService.Dto.Models;

namespace SuperDiploma.Restaurant.DomainService.Dto.Mappings;

public class ShopItemCategoryMapping : Profile
{
    public ShopItemCategoryMapping()
    {
        CreateMap<ShopItemCategoryDbo, ShopItemCategoryFormDto>().ReverseMap();
    }
}