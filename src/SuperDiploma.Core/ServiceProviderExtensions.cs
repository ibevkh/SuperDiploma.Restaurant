using Microsoft.Extensions.DependencyInjection;
using SuperDiploma.Core.Models;

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
}