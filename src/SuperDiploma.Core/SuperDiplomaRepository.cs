using Microsoft.EntityFrameworkCore;
using URF.Core.EF;

namespace SuperDiploma.Core;

public class SuperDiplomaRepository<T> : Repository<T>, ISuperDiplomaRepository<T> where T : class
{
    public SuperDiplomaRepository(DbContext context) : base(context)  {  }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await base.Queryable().ToListAsync();
    }
}