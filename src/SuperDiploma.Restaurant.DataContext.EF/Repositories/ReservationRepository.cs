using Microsoft.EntityFrameworkCore;
using SuperDiploma.Core;
using SuperDiploma.Restaurant.DataContext.Entities.Models;

namespace SuperDiploma.Restaurant.DataContext.EF.Repositories;

public static class ReservationRepository
{
    public static async Task<ReservationDbo?> GetReservationByDateAsync(this ISuperDiplomaRepository<ReservationDbo> repository, DateTime reservationDate)
    {
        return await repository.Queryable()
            .Where(r => r.ReservationTime.Date == reservationDate.Date)
            .FirstOrDefaultAsync();
    }

}