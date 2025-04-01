using AutoMapper;
using SuperDiploma.Restaurant.DataContext.EF.Models.ShopItem;
using SuperDiploma.Restaurant.DataContext.Entities.Models;
using SuperDiploma.Restaurant.DomainService.Dto.Models.ShopItem;
using SuperDiploma.Restaurant.DomainService.Enums;

namespace SuperDiploma.Restaurant.DomainService.Dto.Mappings;

public class ShopItemMapping : Profile
{
    public ShopItemMapping()
    {
        CreateMap<ShopItemDbo, ShopItemListItemDto>()
            .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.CategoryDescription, opts => opts.MapFrom(src => src.Category.Description))
            .ForMember(dest => dest.State, opts => opts.MapFrom(src => src.StateId));

        CreateMap<ShopItemDbo, ShopItemPreviewDto>()
            .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.CategoryDescription, opts => opts.MapFrom(src => src.Category.Description))
            .ForMember(dest => dest.State, opts => opts.MapFrom(src => (ShopItemState)src.StateId));

        CreateMap<ShopItemDbo, ShopItemFormDto>()
            .ForMember(dest => dest.State, opts => opts.MapFrom(src => (ShopItemState)src.StateId));

        CreateMap<ShopItemGridFilterDto, ShopItemGridFilter>()
            .ForMember(dest => dest.StateId, opts => opts.MapFrom(src => (int?)src.State));
    }
}