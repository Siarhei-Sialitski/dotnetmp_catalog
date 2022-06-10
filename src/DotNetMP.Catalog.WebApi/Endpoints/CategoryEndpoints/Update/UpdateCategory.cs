using Ardalis.ApiEndpoints;
using AutoMapper;
using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;
using DotNetMP.Catalog.Core.Interfaces;
using DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.Add;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.Update;

public class UpdateCategory : EndpointBaseAsync
    .WithRequest<UpdateCategoryRequest>
    .WithoutResult
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

    [HttpPut(UpdateCategoryRequest.Route)]
    public async override Task HandleAsync(UpdateCategoryRequest request, CancellationToken cancellationToken = default)
    {
        var category = _mapper.Map<Category>(request.Category);
        await _categoryCommandService.UpdateAsync(category, cancellationToken);
    }
}
