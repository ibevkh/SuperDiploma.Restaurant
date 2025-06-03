using SuperDiploma.Core.Models;
using SuperDiploma.Core.Models.Contracts;
using URF.Core.Abstractions;

namespace SuperDiploma.Core;

public interface ISuperDiplomaRepository<T> : IRepository<T> where T : SuperDiplomaBaseDbo
{
    Task<T> GetByIdAsync(int id);
}