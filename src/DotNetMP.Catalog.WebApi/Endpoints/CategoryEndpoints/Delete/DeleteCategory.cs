using Ardalis.ApiEndpoints;
using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;
using DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.GetById;
using DotNetMP.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.Delete;

public class DeleteCategory : EndpointBaseAsync
    .WithRequest<DeleteCategoryRequest>
    .WithActionResult
{
    private readonly IRepository<Category> _categoryRepository;

    public DeleteCategory(
        IRepository<Category> categoryCommandService)
    {
        _categoryRepository = categoryCommandService;
    }

    [HttpDelete(DeleteCategoryRequest.Route)]
    public async override Task<ActionResult> HandleAsync(DeleteCategoryRequest request, CancellationToken cancellationToken = default)
    {
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
        if (category == null)
        {
            return NotFound();
        }

        await _categoryRepository.DeleteAsync(category, cancellationToken);
        return Ok();
    }
}
