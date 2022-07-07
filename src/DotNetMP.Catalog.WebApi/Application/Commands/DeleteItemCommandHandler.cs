using DotNetMP.Catalog.Core.Aggregates.ItemAggregate;
using DotNetMP.SharedKernel.Exceptions;
using DotNetMP.SharedKernel.Interfaces;
using MediatR;

namespace DotNetMP.Catalog.WebApi.Application.Commands;

public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand>
{
    private readonly IRepository<Item> _itemsRepository;

    public DeleteItemCommandHandler(IRepository<Item> itemsRepository)
    {
        _itemsRepository = itemsRepository;
    }

    public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        var item = await _itemsRepository.GetByIdAsync(request.Id, cancellationToken);
        if (item == null)
        {
            throw new NotFoundException();
        }

        await _itemsRepository.DeleteAsync(item, cancellationToken);

        return Unit.Value;
    }
}
