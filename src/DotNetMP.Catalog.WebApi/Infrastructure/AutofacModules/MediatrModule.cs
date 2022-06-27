using Autofac;
using DotNetMP.Catalog.WebApi.Application.Commands;
using MediatR;
using System.Reflection;

namespace DotNetMP.Catalog.WebApi.Infrastructure.AutofacModules;

public class MediatrModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
            .AsImplementedInterfaces();

        // Register all the Command classes (they implement IRequestHandler) in assembly holding the Commands
        builder.RegisterAssemblyTypes(typeof(CreateCategoryCommand).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IRequestHandler<,>));

        builder.Register<ServiceFactory>(ctx =>
        {
            var c = ctx.Resolve<IComponentContext>();
            return t => c.Resolve(t);
        });
    }
}
