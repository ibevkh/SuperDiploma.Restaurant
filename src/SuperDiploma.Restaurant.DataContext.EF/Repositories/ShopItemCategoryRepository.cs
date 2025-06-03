using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using SuperDiploma.Core;
using SuperDiploma.Restaurant.DataContext.EF.Models;
using SuperDiploma.Restaurant.DataContext.Entities.Models;

namespace SuperDiploma.Restaurant.DataContext.EF.Repositories;

public static class ShopItemCategoryRepository
{
    public static async Task<IEnumerable<DatasourceItem>> GetDatasourceAsync(this ISuperDiplomaRepository<ShopItemCategoryDbo> repository)
    {
        return await repository
            .Queryable()
            .AsNoTracking()
            .Where(d => d.IsDeleted == false)
            .Select(x => new DatasourceItem
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            })
            .ToListAsync();
    }

    public static async Task<IEnumerable<DatasourceItem>> GetFilterDatasourceAsync(this ISuperDiplomaRepository<ShopItemCategoryDbo> repository)
    {
        return await repository
            .Queryable()
            .AsNoTracking()
            .Include(x => x.ShopItems)
            .Where(x => 
                x.IsDeleted == false && 
                x.ShopItems.Select(s => s.IsDeleted).Contains(false))
            .Select(x => new DatasourceItem
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            })
            .Distinct()
            .ToListAsync();
    }

    public static async Task<PaginatedResponse<IEnumerable<ShopItemCategoryDbo>>> GetFilteredListAsync(
        this ISuperDiplomaRepository<ShopItemCategoryDbo> repository,
        ShopItemCategoryGridFilter filter)
    {
        const int defaultPageSize = 10;
        var pageSize = filter.PageSize ?? defaultPageSize;
        var pageNumber = filter.PageNumber ?? 0;

        var query = repository
            .Queryable()
            .AsNoTracking()
            .Where(x => !x.IsDeleted);

        var totalQty = await query.CountAsync();

        var data = await query
            .OrderBy(x => x.Name)
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedResponse<IEnumerable<ShopItemCategoryDbo>>
        {
            TotalQty = totalQty,
            PageSize = pageSize,
            PageNumber = pageNumber,
            Data = data
        };
    }

    //public static async Task<IEnumerable<ShopItemCategoryDbo>> GetListWithShopItemAsync(
    //    this ISuperDiplomaRepository<ShopItemCategoryDbo> repository)
    //{
    //    return await repository.Queryable().AsNoTracking().Where(x => !x.IsDeleted)
    //        .Include(x => x.ShopItems)
    //        .Where(x => x.ShopItems != null && x.ShopItems.Any())
    //        .ToListAsync();
    //}
    public static async Task<IEnumerable<ShopItemCategoryDbo>> GetListWithShopItemAsync(
        this ISuperDiplomaRepository<ShopItemCategoryDbo> repository)
    {
        var categories = await repository.Queryable()
            .AsNoTracking()
            .Where(x => !x.IsDeleted)
            .Include(x => x.ShopItems)
            .ToListAsync();

        // Фільтрація категорій, у яких є хоча б один не видалений товар
        return categories
            .Select(category =>
            {
                category.ShopItems = category.ShopItems
                    ?.Where(item => !item.IsDeleted && item.StateId != 2)
                    .ToList();
                return category;
            })
            .Where(category => category.ShopItems != null && category.ShopItems.Any())
            .ToList();
    }
}