using Ardalis.ApiEndpoints;
using AutoMapper;
using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;
using DotNetMP.Catalog.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.Add;

public class UpdateCategory : EndpointBaseAsync
    .WithRequest<AddCategoryRequest>
    .WithActionResult<AddCategoryResponse>
{
    private readonly ICommandService<Category> _categoryCommandService;
    private readonly IMapper _mapper;

    public UpdateCategory(
        ICommandService<Category> categoryCommandService,
        IMapper mapper)
    {
        _categoryCommandService = categoryCommandService;
        _mapper = mapper;
    }

    [HttpPost(AddCategoryRequest.Route)]
    public async override Task<ActionResult<AddCategoryResponse>> HandleAsync(AddCategoryRequest request, CancellationToken cancellationToken = default)
    {
        var category = _mapper.Map<Category>(request.Category);
        var createdCategory = await _categoryCommandService.AddAsync(category, cancellationToken);

        return _mapper.Map<AddCategoryResponse>(createdCategory);
    }
}
