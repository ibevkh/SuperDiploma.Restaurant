using Microsoft.EntityFrameworkCore;
using SuperDiploma.Core;
using SuperDiploma.Restaurant.DataContext.EF.Models;
using SuperDiploma.Restaurant.DataContext.Entities.Models;

namespace SuperDiploma.Restaurant.DataContext.EF.Repositories;

public static class OrderReviewRepository
{
    public static async Task<PaginatedResponse<IEnumerable<OrderDbo>>> GetPaginatedOrdersAsync(
        this ISuperDiplomaRepository<OrderDbo> repository,
        OrderGridFilter filter)
    {
        const int defaultPageSize = 10;
        var pageSize = filter.PageSize ?? defaultPageSize;
        var pageNumber = filter.PageNumber ?? 0;

        var query = repository
            .Queryable()
            .AsNoTracking()
            //.Include(o => o.Customer)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.ShopItem);

        var totalQty = await query.CountAsync();

        var data = await query
            .OrderByDescending(o => o.CreatedAt)
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedResponse<IEnumerable<OrderDbo>>
        {
            TotalQty = totalQty,
            PageSize = pageSize,
            PageNumber = pageNumber,
            Data = data
        };
    }
}