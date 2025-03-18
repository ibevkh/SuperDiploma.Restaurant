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
}