using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;
using DotNetMP.Catalog.Core.Aggregates.ItemAggregate;
using DotNetMP.SharedKernel.Exceptions;
using DotNetMP.SharedKernel.Interfaces;
using MediatR;

namespace DotNetMP.Catalog.WebApi.Application.Commands;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly IRepository<Category> _categoryRepository;
    private readonly IRepository<Item> _itemsRepository;

    public DeleteCategoryCommandHandler(
        IRepository<Category> categoryRepository,
        IRepository<Item> itemsRepository)
    {
        _categoryRepository = categoryRepository;
        _itemsRepository = itemsRepository;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);
        if (category == null)
        {
            throw new NotFoundException();
        }

        var items = await _itemsRepository.ListAsync(cancellationToken);

        var itemsToDelete = items
            .Where(i => i.CategoryId == category.Id);

        foreach (var item in itemsToDelete)
        {
            await _itemsRepository.DeleteAsync(item, cancellationToken);
        }

        await _categoryRepository.DeleteAsync(category, cancellationToken);

        return Unit.Value;
    }
}
