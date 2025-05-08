namespace SuperDiploma.Restaurant.DataContext.EF.Models;

public class RestaurantMenuCardFilter
{
    public int? CategoryId { get; set; }
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
}