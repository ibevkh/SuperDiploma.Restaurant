using SuperDiploma.Core;
using SuperDiploma.Core.Models;
using URF.Core.Abstractions;

namespace SuperDiploma.Restaurant.DataContext.EF;

public interface IRestaurantUnitOfWork : IUnitOfWork, IDisposable
{
    ISuperDiplomaRepository<T> Repository<T>() where T : SuperDiplomaBaseDbo;
    public Task<int> SaveChangesAsync();
}