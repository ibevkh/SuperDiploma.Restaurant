using Microsoft.Extensions.DependencyInjection;
using SuperDiploma.Core.Models;
using URF.Core.Abstractions;
using URF.Core.EF;

namespace SuperDiploma.Core;

public static class ServiceProviderExtensions
{
    //public static IServiceCollection AddTrackableRepository<T>(this IServiceCollection services) where T : Entity
    //{
    //    return services.AddScoped<IMyTrackableRepository<T>, MyTrackableRepository<T>>();
    //}

    public static IServiceCollection AddRepository<T>(this IServiceCollection services) where T : SuperDiplomaBaseDbo
    {
        return services.AddScoped<ISuperDiplomaRepository<T>, SuperDiplomaRepository<T>>();
    }

    public static IServiceCollection AddTempRepository<T>(this IServiceCollection services) where T : class
    {
        return services.AddScoped<IRepository<T>, Repository<T>>();
    }
}