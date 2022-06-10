using DotNetMP.Catalog.Infrastructure.Data;
using DotNetMP.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetMP.Catalog.Infrastructure;

public static class DependenciesRegistrarExt
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt => {
            opt.UseSqlServer(configuration.GetConnectionString("SqllServerConnection"));
        });

        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        return services;
    }
}
