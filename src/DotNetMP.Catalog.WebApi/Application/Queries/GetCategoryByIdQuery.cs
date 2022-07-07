using DotNetMP.Catalog.WebApi.Application.Models;
using MediatR;

namespace DotNetMP.Catalog.WebApi.Application.Queries;

public class GetCategoryByIdQuery : IRequest<CategoryRecord>
{
    public Guid Id { get; private set; }

    public GetCategoryByIdQuery(Guid id)
    {
        Id = id;
    }
}
