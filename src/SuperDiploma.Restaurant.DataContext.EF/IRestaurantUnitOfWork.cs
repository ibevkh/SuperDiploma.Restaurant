using SuperDiploma.Core;
using URF.Core.Abstractions;

namespace SuperDiploma.Restaurant.DataContext.EF;

public interface IRestaurantUnitOfWork : IUnitOfWork, IDisposable
{
    ISuperDiplomaRepository<T> Repository<T>() where T : class;
    public Task<int> SaveChangesAsync();
}