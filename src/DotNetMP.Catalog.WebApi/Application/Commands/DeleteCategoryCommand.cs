using MediatR;

namespace DotNetMP.Catalog.WebApi.Application.Commands;

public class DeleteCategoryCommand : IRequest
{
    public Guid Id { get; private set; }

    public DeleteCategoryCommand(Guid id)
    {
        Id = id;
    }
}
