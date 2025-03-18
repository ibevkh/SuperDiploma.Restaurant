using Microsoft.EntityFrameworkCore;
using SuperDiploma.Core;
using SuperDiploma.Restaurant.DataContext.EF.Models.ShopItem;
using SuperDiploma.Restaurant.DataContext.Entities.Models;

namespace SuperDiploma.Restaurant.DataContext.EF.Repositories;

public static class ShopItemRepository
{
    public static async Task<ShopItemDbo> GetByIdAsync(this ISuperDiplomaRepository<ShopItemDbo> repository,
        int id)
    {
        return await repository
            .Queryable()
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == id && d.IsDeleted == false);
    }

    public static async Task<ShopItemDbo> GetPreviewByIdAsync(
        this ISuperDiplomaRepository<ShopItemDbo> repository, int id)
    {
        return await repository
            .Queryable()
            .AsNoTracking()
            .Include(x => x.Category)
            .FirstOrDefaultAsync(d => d.Id == id && d.IsDeleted == false);
    }

    // DO NOT USE. Just only for demonstration of another approach of receiving the item preview
    public static async Task<ShopItemPreview> GetShopItemPreviewByIdAsync2(
        this ISuperDiplomaRepository<ShopItemDbo> repository, int id)
    {
        return await repository
            .Queryable()
            .AsNoTracking()
            .Where(d => d.Id == id && d.IsDeleted == false)
            .Include(x => x.Category)
            .Select(x => new ShopItemPreview
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
                StateId = x.StateId,
                Image = x.Image,
                CategoryName = x.Category.Name,
                CategoryDescription = x.Category.Description
            })
            .FirstOrDefaultAsync();
    }

    public static async Task<IEnumerable<ShopItemDbo>> GetFilteredListAsync(
        this ISuperDiplomaRepository<ShopItemDbo> repository, ShopItemGridFilter filter)
    {
        const int defaultPageSize = 10;

        return await repository
            .Queryable()
            .AsNoTracking()
            .Where(x =>
                x.IsDeleted == false &&
                (!filter.CategoryId.HasValue || x.CategoryId == filter.CategoryId.Value) &&
                (!filter.StateId.HasValue || x.StateId == filter.StateId)
            )
            .OrderBy(x => x.CreatedAt)
            .Skip((filter.PageNumber ?? 0) * filter.PageSize ?? defaultPageSize)
            .Take(filter.PageSize ?? defaultPageSize)
            .Include(x => x.Category)
            .ToListAsync();
    }
}