using Ardalis.ApiEndpoints;
using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;
using DotNetMP.Catalog.Core.Interfaces;
using DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.GetById;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.Delete;

public class DeleteCategory : EndpointBaseAsync
    .WithRequest<DeleteCategoryRequest>
    .WithoutResult
{
    private readonly ICommandService<Category> _categoryCommandService;

    public DeleteCategory(
        ICommandService<Category> categoryCommandService)
    {
        _categoryCommandService = categoryCommandService;
    }

    [HttpDelete(DeleteCategoryRequest.Route)]
    public async override Task HandleAsync(DeleteCategoryRequest request, CancellationToken cancellationToken = default)
    {
        await _categoryCommandService.DeleteAsync(request.CategoryId, cancellationToken);
    }
}
