using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;

namespace DotNetMP.Catalog.Infrastructure.ServiceBus;

internal class ServiceBusRepository : IServiceBusRepository
{
    private readonly ServiceBusSender _sender;

    public ServiceBusRepository(
        ServiceBusClient serviceBusClient,
        IConfiguration configuration)
    {
        _sender = serviceBusClient.CreateSender(configuration["ItemUpdatedQueue"]);
    }

    public async Task SendMessageAsync(string message, CancellationToken cancellationToken)
    {
        var sbMessage = new ServiceBusMessage(message);
        await _sender.SendMessageAsync(sbMessage, cancellationToken);
    }
}
