using Microsoft.Extensions.DependencyInjection;

namespace SuperDiploma.Core;

public static class ServiceProviderExtensions
{
    //public static IServiceCollection AddTrackableRepository<T>(this IServiceCollection services) where T : Entity
    //{
    //    return services.AddScoped<IMyTrackableRepository<T>, MyTrackableRepository<T>>();
    //}

    public static IServiceCollection AddRepository<T>(this IServiceCollection services) where T : class
    {
        return services.AddScoped<ISuperDiplomaRepository<T>, SuperDiplomaRepository<T>>();
    }
}