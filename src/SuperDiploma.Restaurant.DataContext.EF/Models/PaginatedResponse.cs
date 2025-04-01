namespace SuperDiploma.Restaurant.DataContext.EF.Models;

public class PaginatedResponse<T>
{
    public int TotalQty { get; set; }
    public int? PageSize { get; set; }
    public int? PageNumber { get; set; }
    public T Data { get; set; }
}