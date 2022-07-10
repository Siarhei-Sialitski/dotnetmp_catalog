namespace DotNetMP.Catalog.Infrastructure.ServiceBus;

public interface IServiceBusRepository
{
    Task SendMessageAsync(string message, CancellationToken cancellationToken);
}
