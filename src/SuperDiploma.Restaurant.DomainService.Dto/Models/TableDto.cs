namespace SuperDiploma.Restaurant.DomainService.Dto.Models;

internal class TableDto
{
    public int Id { get; set; }
    public int TableNumber { get; set; }
    public int Capacity { get; set; }
    public bool IsAvailable { get; set; }
}