using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;
using DotNetMP.Catalog.WebApi.Application.Models;
using DotNetMP.SharedKernel.Exceptions;
using DotNetMP.SharedKernel.Interfaces;
using MediatR;

namespace DotNetMP.Catalog.WebApi.Application.Queries;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryRecord>
{
    private readonly IRepository<Category> _categoryRepository;

    public GetCategoryByIdQueryHandler(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryRecord> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);
        if (category == null)
        {
            throw new NotFoundException();
        }

        return new CategoryRecord(category.Id, category.Name, category.Image, category.ParentCategoryId);
    }
}
