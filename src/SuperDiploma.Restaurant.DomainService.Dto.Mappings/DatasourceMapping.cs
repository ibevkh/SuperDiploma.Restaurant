using AutoMapper;
using SuperDiploma.Restaurant.DataContext.EF.Models;
using SuperDiploma.Restaurant.DomainService.Dto.Models;

namespace SuperDiploma.Restaurant.DomainService.Dto.Mappings;

public class DatasourceMapping : Profile
{
    public DatasourceMapping()
    {
        CreateMap<DatasourceItem, DatasourceItemDto>().ReverseMap();

    }
}