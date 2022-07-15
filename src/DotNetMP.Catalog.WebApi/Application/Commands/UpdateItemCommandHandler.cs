using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;
using DotNetMP.Catalog.Core.Aggregates.ItemAggregate;
using DotNetMP.Catalog.Infrastructure.ServiceBus;
using DotNetMP.SharedKernel.Exceptions;
using DotNetMP.SharedKernel.IntegrationEvents;
using DotNetMP.SharedKernel.Interfaces;
using MediatR;
using Newtonsoft.Json;

namespace DotNetMP.Catalog.WebApi.Application.Commands;

public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand>
{
    private readonly IRepository<Item> _itemsRepository;
    private readonly IRepository<Category> _categoriesRepository;
    private readonly IServiceBusRepository _serviceBusRepository;

    public UpdateItemCommandHandler(
        IRepository<Item> itemsRepository,
        IRepository<Category> categoriesRepository,
        IServiceBusRepository serviceBusRepository)
    {
        _itemsRepository = itemsRepository;
        _categoriesRepository = categoriesRepository;
        _serviceBusRepository = serviceBusRepository;
    }

    public async Task<Unit> Handle(UpdateItemCommand itemToUpdate, CancellationToken cancellationToken)
    {
        var item = await _itemsRepository.GetByIdAsync(itemToUpdate.Id, cancellationToken);
        if (item == null)
        {
            throw new NotFoundException();
        }

        var category = await _categoriesRepository.GetByIdAsync(itemToUpdate.CategoryId, cancellationToken);
        if (category == null)
        {
            throw new NotFoundException();
        }

        item.UpdateName(itemToUpdate.Name);
        item.UpdateDescription(itemToUpdate.Description);
        item.UpdatePrice(itemToUpdate.Price);
        item.UpdateImage(itemToUpdate.Image);
        item.UpdateCategory(category);

        await _itemsRepository.UpdateAsync(item, cancellationToken);

        var itemUpdated = new ItemUpdatedIntegrationEvent(item.Id, item.Name, item.Price, item.Description, item.Image);
        await _serviceBusRepository.SendMessageAsync(JsonConvert.SerializeObject(itemUpdated), cancellationToken);

        return Unit.Value;
    }
}
