using DotNetMP.Catalog.WebApi.Application.Models;
using MediatR;

namespace DotNetMP.Catalog.WebApi.Application.Queries;

public class GetItemByIdQuery : IRequest<ItemRecord>
{
    public Guid Id { get; private set; }

    public GetItemByIdQuery(Guid id)
    {
        Id = id;
    }
}
