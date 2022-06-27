using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;
using DotNetMP.SharedKernel.Interfaces;
using MediatR;

namespace DotNetMP.Catalog.WebApi.Application.Commands;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
{
    private readonly IRepository<Category> _categoryRepository;

    public CreateCategoryCommandHandler(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category? parentCategory = null;
        if (request.ParentCategoryId.HasValue)
        {
            parentCategory = await _categoryRepository.GetByIdAsync(request.ParentCategoryId.Value);
            if (parentCategory == null)
            {
                throw new InvalidOperationException("Parent category doesn't exist.");
            }

        }
        var category = new Category(request.Name, request.Image, parentCategory);

        var createdCategory = await _categoryRepository.AddAsync(category, cancellationToken);

        return createdCategory.Id;
    }
}
