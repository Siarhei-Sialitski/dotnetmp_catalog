using DotNetMP.Catalog.Core.Interfaces;
using DotNetMP.Catalog.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetMP.Catalog.Core;

public static class DependenciesRegistrar
{
    public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
    {
        services.AddScoped(typeof(ICommandService<>), typeof(CommandService<>));
        services.AddScoped(typeof(IQueryService<>), typeof(QueryService<>));

        return services;
    }
}
