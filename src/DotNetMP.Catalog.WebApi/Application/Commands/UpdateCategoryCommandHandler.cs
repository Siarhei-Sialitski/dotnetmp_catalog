using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;
using DotNetMP.SharedKernel.Exceptions;
using DotNetMP.SharedKernel.Interfaces;
using MediatR;

namespace DotNetMP.Catalog.WebApi.Application.Commands;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IRepository<Category> _categoryRepository;

    public UpdateCategoryCommandHandler(IRepository<Category> categoryRepositry)
    {
        _categoryRepository = categoryRepositry;
    }

    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);
        if (category == null)
        {
            throw new NotFoundException();
        }

        Category? parentCategory = null;
        if (request.ParentCategoryId.HasValue)
        {
            parentCategory = await _categoryRepository.GetByIdAsync(request.ParentCategoryId.Value);
            if (parentCategory == null)
            {
                throw new NotFoundException("Parent category doesn't exist.");
            }
        }

        category.UpdateName(request.Name);
        category.UpdateImage(request.Image);
        category.UpdateParentCategory(parentCategory);

        await _categoryRepository.UpdateAsync(category, cancellationToken);

        return Unit.Value;
    }
}
