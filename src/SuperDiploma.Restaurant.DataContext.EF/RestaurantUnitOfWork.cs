using Microsoft.EntityFrameworkCore;
using SuperDiploma.Core;
using SuperDiploma.Core.Models;
using URF.Core.EF;

namespace SuperDiploma.Restaurant.DataContext.EF;

public class RestaurantUnitOfWork : UnitOfWork, IRestaurantUnitOfWork
{
    private readonly DbContext _context;
    private readonly IServiceProvider _serviceProvider;
    public RestaurantUnitOfWork(DbContext context, IServiceProvider serviceProvider) : base(context)
    {
        _context = context;
        _serviceProvider = serviceProvider;
    }

    public void Dispose()
    {
        _context?.Dispose();
    }

    public ISuperDiplomaRepository<T> Repository<T>() where T : SuperDiplomaBaseDbo
    {
        return _serviceProvider.GetService(typeof(ISuperDiplomaRepository<T>)) as ISuperDiplomaRepository<T> ?? throw new InvalidOperationException();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}