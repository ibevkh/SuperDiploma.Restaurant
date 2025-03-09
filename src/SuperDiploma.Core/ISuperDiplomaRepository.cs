using URF.Core.Abstractions;

namespace SuperDiploma.Core;

public interface ISuperDiplomaRepository<T> : IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
}