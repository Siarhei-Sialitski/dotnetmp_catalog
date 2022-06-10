using DotNetMP.Catalog.Core;
using DotNetMP.Catalog.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMP.Catalog.WebApi;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.UseNamespaceRouteToken();
        }).AddNewtonsoftJson(options => 
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        );

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressInferBindingSourcesForParameters = true;
        });

        services.AddAutoMapper(typeof(Startup));

        services.AddCoreDependencies();
        services.AddInfrastructureDependencies(Configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });


        //using (var scope = app.ApplicationServices.CreateScope())
        //{
        //    var services = scope.ServiceProvider;

        //    try
        //    {
        //        var context = services.GetRequiredService<AppDbContext>();
        //        context.Database.Migrate();
        //        context.Database.EnsureCreated();
        //        SeedData.Initialize(services);
        //    }
        //    catch (Exception ex)
        //    {
        //        var logger = services.GetRequiredService<ILogger<Program>>();
        //        logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
        //    }
        //}
    }
}
