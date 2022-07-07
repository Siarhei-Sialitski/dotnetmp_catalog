using MediatR;

namespace DotNetMP.Catalog.WebApi.Application.Commands;
public class DeleteItemCommand : IRequest
{
    public Guid Id { get; private set; }

    public DeleteItemCommand(Guid id)
    {
        Id = id;
    }
}
