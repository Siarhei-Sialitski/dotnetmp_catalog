using Ardalis.ApiEndpoints;
using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;
using DotNetMP.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.Get;

public class GetCategory : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<GetCategoryResponse>
{
    private readonly IRepository<Category> _categoryRepository;

    public GetCategory(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet("/Categories")]
    public async override Task<ActionResult<GetCategoryResponse>> HandleAsync(CancellationToken cancellationToken = default)
    {
        var categories = await _categoryRepository.ListAsync(cancellationToken);

        if (!categories.Any())
        {
            return NotFound();
        }

        var response = new GetCategoryResponse()
        {
            Categories = categories
                .Select(c => new CategoryRecord(c.Id, c.Name, c.Image, c.ParentCategoryId))
                .ToList()
        };

        return response;
    }
}
