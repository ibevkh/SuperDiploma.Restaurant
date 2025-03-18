using SuperDiploma.Restaurant.DomainService.Enums;

namespace SuperDiploma.Restaurant.DomainService.Dto.Models.ShopItem;

/// <summary>
/// Represents a model of filter used for shop item's grid
/// </summary>
public class ShopItemGridFilterDto
{
    /// <summary>Page number</summary>
    /// <remarks>Page numbers start from 0 index</remarks>
    /// <example>0</example>
    public int? PageNumber { get; set; }

    /// <summary>Quantity of items on page</summary>
    /// <example>10</example>
    public int? PageSize { get; set; }

    /// <summary>Identifier of category</summary>
    /// <example>1</example>
    public int? CategoryId { get; set; }

    /// <summary>Shop item state</summary>
    /// <example>1</example>
    public ShopItemState? State { get; set; }
}