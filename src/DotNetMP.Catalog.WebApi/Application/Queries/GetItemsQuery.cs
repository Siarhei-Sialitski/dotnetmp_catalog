using DotNetMP.Catalog.WebApi.Application.Models;
using MediatR;

namespace DotNetMP.Catalog.WebApi.Application.Queries;

public class GetItemsQuery : IRequest<PaginatedItemViewModel<ItemRecord>>
{
    public int PageSize { get; private set; }
    public int PageIndex { get; private set; }
    public Guid? CategoryId { get; private set; }

    public GetItemsQuery(Guid? categoryId, int pageSize, int pageIndex)
    {
        PageSize = pageSize;
        PageIndex = pageIndex;
        CategoryId = categoryId;
    }
}
