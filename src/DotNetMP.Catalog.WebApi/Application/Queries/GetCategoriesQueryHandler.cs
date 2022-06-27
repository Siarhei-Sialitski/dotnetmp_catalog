using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;
using DotNetMP.Catalog.WebApi.Application.Models;
using DotNetMP.SharedKernel.Interfaces;
using MediatR;

namespace DotNetMP.Catalog.WebApi.Application.Queries;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IList<CategoryRecord>>
{
    private readonly IRepository<Category> _categoryRepository;

    public GetCategoriesQueryHandler(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IList<CategoryRecord>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.ListAsync(cancellationToken);

        return categories
                .Select(c => new CategoryRecord(c.Id, c.Name, c.Image, c.ParentCategoryId))
                .ToList();
    }
}
