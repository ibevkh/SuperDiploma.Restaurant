namespace SuperDiploma.Restaurant.DomainService.Dto.Models;

public class PaginatedResponseDto<T>
{
    public int TotalQty { get; set; }
    public int? PageSize { get; set; }
    public int? PageNumber { get; set; }
    public T Data { get; set; }
}