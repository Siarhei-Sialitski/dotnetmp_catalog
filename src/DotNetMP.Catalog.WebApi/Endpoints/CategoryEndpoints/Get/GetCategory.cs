using Ardalis.ApiEndpoints;
using AutoMapper;
using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;
using DotNetMP.Catalog.Core.Interfaces;
using DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.Get;

public class GetCategory : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<GetCategoryResponse>
{
    private readonly IQueryService<Category> _categoryQueryService;
    private readonly IMapper _mapper;

    public GetCategory(
        IQueryService<Category> categoryQueryService,
        IMapper mapper)
    {
        _categoryQueryService = categoryQueryService;
        _mapper = mapper;
    }

    [HttpGet("/Categories")]
    public async override Task<ActionResult<GetCategoryResponse>> HandleAsync(CancellationToken cancellationToken = default)
    {
        var categories = await _categoryQueryService.GetListAsync(cancellationToken);

        if (!categories.Any())
        {
            return NoContent();
        }

        var categoryViewModels = _mapper.Map<List<ReadCategoryViewModel>>(categories);
        return new GetCategoryResponse() { Categories = categoryViewModels};
    }
}
