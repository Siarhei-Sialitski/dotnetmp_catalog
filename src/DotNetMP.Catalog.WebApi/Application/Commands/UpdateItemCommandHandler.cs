using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;
using DotNetMP.Catalog.Core.Aggregates.ItemAggregate;
using DotNetMP.SharedKernel.Exceptions;
using DotNetMP.SharedKernel.Interfaces;
using MediatR;

namespace DotNetMP.Catalog.WebApi.Application.Commands;

public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand>
{
    private readonly IRepository<Item> _itemsRepository;
    private readonly IRepository<Category> _categoriesRepository;

    public UpdateItemCommandHandler(
        IRepository<Item> itemsRepository,
        IRepository<Category> categoriesRepository)
    {
        _itemsRepository = itemsRepository;
        _categoriesRepository = categoriesRepository;
    }

    public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var item = await _itemsRepository.GetByIdAsync(request.Id, cancellationToken);
        if (item == null)
        {
            throw new NotFoundException();
        }

        var category = await _categoriesRepository.GetByIdAsync(request.Id, cancellationToken);
        if (category == null)
        {
            throw new NotFoundException();
        }

        item.UpdateName(request.Name);
        item.UpdateDescription(request.Description);
        item.UpdatePrice(request.Price);
        item.UpdateImage(request.Image);
        item.UpdateCategory(category);

        return Unit.Value;
    }
}
