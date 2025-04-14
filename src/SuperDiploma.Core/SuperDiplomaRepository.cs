using Microsoft.EntityFrameworkCore;
using SuperDiploma.Core.Models;
using URF.Core.EF;

namespace SuperDiploma.Core;

public class SuperDiplomaRepository<T> : Repository<T>, ISuperDiplomaRepository<T> where T : SuperDiplomaBaseDbo
{
    public SuperDiplomaRepository(DbContext context) : base(context)  {  }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await base.Queryable().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await base
            .Queryable()
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == id && d.IsDeleted == false);
        // Якщо успадкуюся від SuperDiplomaBaseDbo, то можна скористатися 3 рядком.
    }

    //public async Task<T> RemoveById(int id, int userId)
    //{
    //    var item = await GetByIdAsync(id);

    //    if (item == null)
    //    {
    //        throw new InvalidOperationException("Об'єкт не знайдений.");
    //    }

    //    item.IsDeleted = true;
    //    item.ModifiedAt = DateTimeOffset.Now;
    //    item.ModifiedBy = userId;
    //    base.Update(item);

    //    return item;
    //}
}