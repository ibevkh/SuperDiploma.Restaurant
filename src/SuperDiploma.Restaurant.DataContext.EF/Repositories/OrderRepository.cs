using Microsoft.EntityFrameworkCore;
using SuperDiploma.Core;
using SuperDiploma.Restaurant.DataContext.Entities.Models;

namespace SuperDiploma.Restaurant.DataContext.EF.Repositories;

public static class OrderRepository
{
    public static async Task<IEnumerable<OrderDbo>> GetOrderWithDetails(this ISuperDiplomaRepository<OrderDbo> repository)
    {
        return await repository.Queryable().Include(x => x.Reservation).ToListAsync();
    }
}