using DotNetMP.Catalog.Core.Aggregates.ItemAggregate;
using DotNetMP.Catalog.WebApi.Application.Models;
using DotNetMP.SharedKernel.Exceptions;
using DotNetMP.SharedKernel.Interfaces;
using MediatR;

namespace DotNetMP.Catalog.WebApi.Application.Queries;

public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, ItemRecord>
{
    private readonly IRepository<Item> _itemsRepository;

    public GetItemByIdQueryHandler(IRepository<Item> itemsRepository)
    {
        _itemsRepository = itemsRepository;
    }

    public async Task<ItemRecord> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
    {
        var item = await _itemsRepository.GetByIdAsync(request.Id, cancellationToken);
        if (item == null)
        {
            throw new NotFoundException();
        }

        return new ItemRecord(item.Id, item.CategoryId, item.Name, item.Price, item.Amount, item.Description, item.Image);
    }
}
