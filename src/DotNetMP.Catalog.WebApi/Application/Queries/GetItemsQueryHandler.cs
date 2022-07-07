using DotNetMP.Catalog.Core.Aggregates.ItemAggregate;
using DotNetMP.Catalog.WebApi.Application.Models;
using DotNetMP.SharedKernel.Interfaces;
using MediatR;

namespace DotNetMP.Catalog.WebApi.Application.Queries;

public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, PaginatedItemViewModel<ItemRecord>>
{
    private readonly IRepository<Item> _itemsRepository;

    public GetItemsQueryHandler(IRepository<Item> itemsRepository)
    {
        _itemsRepository = itemsRepository;
    }

    public async Task<PaginatedItemViewModel<ItemRecord>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
    {
        var totalItems = await _itemsRepository.ListAsync(cancellationToken);

        if (request.CategoryId.HasValue)
        {
            totalItems = totalItems
                .Where(i => i.CategoryId == request.CategoryId.Value)
                .ToList();
        }

        var totalCount = totalItems.LongCount();

        var itemsOnPage = totalItems
            .Skip(request.PageSize * request.PageIndex)
            .Take(request.PageSize)            
            .Select(i => new ItemRecord(i.Id, i.CategoryId, i.Name, i.Price, i.Amount, i.Description, i.Image))
            .ToList();

        return new PaginatedItemViewModel<ItemRecord>(request.PageIndex, request.PageSize, totalCount, itemsOnPage);
    }
}
