using Ardalis.ApiEndpoints;
using AutoMapper;
using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;
using DotNetMP.Catalog.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.GetById;

public class GetCategory : EndpointBaseAsync
    .WithRequest<DeleteCategoryRequest>
    .WithActionResult<GetCategoryByIdResponse>
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

    [HttpGet(DeleteCategoryRequest.Route)]
    public async override Task<ActionResult<GetCategoryByIdResponse>> HandleAsync(DeleteCategoryRequest request, CancellationToken cancellationToken = default)
    {
        var category = await _categoryQueryService.GetAsync(request.CategoryId, cancellationToken);

        if (category == null)
        {
            return NoContent();
        }

        return _mapper.Map<GetCategoryByIdResponse>(category);
    }
}
