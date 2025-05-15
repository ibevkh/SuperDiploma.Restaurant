using AutoMapper;
using SuperDiploma.Restaurant.DataContext.EF.Models;
using SuperDiploma.Restaurant.DataContext.Entities.Models;
using SuperDiploma.Restaurant.DomainService.Dto.Models;
using SuperDiploma.Restaurant.DomainService.Dto.Models.CategoryShopItem;

namespace SuperDiploma.Restaurant.DomainService.Dto.Mappings;

public class ShopItemCategoryMapping : Profile
{
    public ShopItemCategoryMapping()
    {
        CreateMap<ShopItemCategoryDbo, ShopItemCategoryFormDto>().ReverseMap();

        CreateMap<ShopItemCategoryGridFilterDto, ShopItemCategoryGridFilter>();
        CreateMap<ShopItemCategoryGridFilter, ShopItemCategoryGridFilterDto>();

        CreateMap<PaginatedResponse<IEnumerable<ShopItemCategoryDbo>>,
            PaginatedResponseDto<IEnumerable<ShopItemCategoryGridDto>>>();
        CreateMap<PaginatedResponse<IEnumerable<ShopItemCategoryGridDto>>,
            PaginatedResponseDto<IEnumerable<ShopItemCategoryDbo>>>();

        CreateMap<ShopItemCategoryDbo, ShopItemCategoryGridDto>();
        CreateMap<ShopItemCategoryGridDto, ShopItemCategoryDbo>();

    }
}