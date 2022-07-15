using Azure.Messaging.ServiceBus;
using DotNetMP.Catalog.Infrastructure.Data;
using DotNetMP.Catalog.Infrastructure.ServiceBus;
using DotNetMP.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetMP.Catalog.Infrastructure;

public static class DependenciesRegistrarExt
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt => {
            opt.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"));
        });

        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

        services.AddAzureClients(builder =>
        {
            builder.AddServiceBusClient(configuration.GetConnectionString("ServiceBusConnectionString"))
                .ConfigureOptions(configuration =>
                {
                    configuration.RetryOptions = new ServiceBusRetryOptions()
                    {
                        Mode = ServiceBusRetryMode.Exponential
                    };
                });
        });

        services.AddTransient<IServiceBusRepository, ServiceBusRepository>();

        return services;
    }
}
