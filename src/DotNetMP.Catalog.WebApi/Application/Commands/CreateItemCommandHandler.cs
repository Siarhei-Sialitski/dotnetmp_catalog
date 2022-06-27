using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;
using DotNetMP.Catalog.Core.Aggregates.ItemAggregate;
using DotNetMP.SharedKernel.Interfaces;
using MediatR;

namespace DotNetMP.Catalog.WebApi.Application.Commands;

public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, Guid>
{
    private readonly IRepository<Category> _categoryRepository;
    private readonly IRepository<Item> _itemRepository;

    public CreateItemCommandHandler(
        IRepository<Category> categoryRepository,
        IRepository<Item> itemRepository)
    {
        _categoryRepository = categoryRepository;
        _itemRepository = itemRepository;
    }

    public async Task<Guid> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);
        if (category == null)
        {
            throw new InvalidOperationException("Category not found.");
        }

        var item = new Item(category, request.Name, request.Price, request.Amount, request.Description, request.Image);
        var addedItem = await _itemRepository.AddAsync(item, cancellationToken);

        return addedItem.Id;
    }
}
