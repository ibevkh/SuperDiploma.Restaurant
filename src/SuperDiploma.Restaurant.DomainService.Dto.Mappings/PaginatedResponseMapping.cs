using AutoMapper;
using SuperDiploma.Restaurant.DataContext.EF.Models;
using SuperDiploma.Restaurant.DomainService.Dto.Models;

namespace SuperDiploma.Restaurant.DomainService.Dto.Mappings;

public class PaginatedResponseMapping : Profile
{
    public PaginatedResponseMapping()
    {
        CreateMap(typeof(PaginatedResponse<>), typeof(PaginatedResponseDto<>)).ReverseMap();
    }
}