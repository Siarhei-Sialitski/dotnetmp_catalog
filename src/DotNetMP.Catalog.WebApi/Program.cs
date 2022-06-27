using Autofac.Extensions.DependencyInjection;

namespace DotNetMP.Catalog.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .Build()
            .SeedData()
            .Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
