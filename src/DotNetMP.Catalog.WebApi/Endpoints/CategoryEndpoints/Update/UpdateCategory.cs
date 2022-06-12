using Ardalis.ApiEndpoints;
using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;
using DotNetMP.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.Update;

public class UpdateCategory : EndpointBaseAsync
    .WithRequest<UpdateCategoryRequest>
    .WithActionResult
{
    private readonly IRepository<Category> _categoryRepository;

    public UpdateCategory(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpPut(UpdateCategoryRequest.Route)]
    public async override Task<ActionResult> HandleAsync(UpdateCategoryRequest request, CancellationToken cancellationToken = default)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);
        if (category == null)
        {
            return NotFound();
        }

        // Update logic
        await _categoryRepository.UpdateAsync(category, cancellationToken);

        return Ok(category);
    }
}
