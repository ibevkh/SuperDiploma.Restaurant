namespace SuperDiploma.Restaurant.DomainService.Dto.Models.ShopItem;

public class ShopItemFormDatasourceDto
{
    public IEnumerable<DatasourceItemDto> Categories { get; set; } // "categories": [{"id": 1}, {"id:2}, ...]
    public IEnumerable<DatasourceItemDto> States { get; set; } // "states": [{"id": 1}, {"id:2}, ...]
}