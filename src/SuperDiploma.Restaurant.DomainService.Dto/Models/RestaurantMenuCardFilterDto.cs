namespace SuperDiploma.Restaurant.DomainService.Dto.Models;

public class RestaurantMenuCardFilterDto
{
    public int? CategoryId { get; set; }
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
}