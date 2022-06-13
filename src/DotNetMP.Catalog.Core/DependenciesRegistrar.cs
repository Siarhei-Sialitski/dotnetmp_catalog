using Microsoft.Extensions.DependencyInjection;

namespace DotNetMP.Catalog.Core;

public static class DependenciesRegistrar
{
    public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
    {
        return services;
    }
}
