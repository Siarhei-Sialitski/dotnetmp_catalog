using Ardalis.ApiEndpoints;
using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;
using DotNetMP.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.GetById;

public class GetCategory : EndpointBaseAsync
    .WithRequest<DeleteCategoryRequest>
    .WithActionResult<GetCategoryByIdResponse>
{
    private readonly IRepository<Category> _categoryRepository;

    public GetCategory(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet(DeleteCategoryRequest.Route)]
    public async override Task<ActionResult<GetCategoryByIdResponse>> HandleAsync(DeleteCategoryRequest request, CancellationToken cancellationToken = default)
    {
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);

        if (category == null)
        {
            return NoContent();
        }

        return new GetCategoryByIdResponse(
            new CategoryRecord(category.Id, category.Name, category.Image, category.ParentCategoryId));
    }
}
