using Ardalis.ApiEndpoints;
using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;
using DotNetMP.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.Add;

public class AddCategory : EndpointBaseAsync
    .WithRequest<AddCategoryRequest>
    .WithActionResult<AddCategoryResponse>
{
    private readonly IRepository<Category> _categoryRepository;

    public AddCategory(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpPost(AddCategoryRequest.Route)]
    public async override Task<ActionResult<AddCategoryResponse>> HandleAsync(AddCategoryRequest request, CancellationToken cancellationToken = default)
    {
        var category = new Category(request.Name, request.Image, request.ParentCategoryId);

        var createdCategory = await _categoryRepository.AddAsync(category, cancellationToken);

        return new AddCategoryResponse(
            new CategoryRecord(createdCategory.Id, createdCategory.Name, createdCategory.Image, createdCategory.ParentCategoryId));
    }
}
