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
        var updateCategory = request.Category;

        if (updateCategory == null)
        {
            return BadRequest();
        }

        var category = await _categoryRepository.GetByIdAsync(updateCategory.Id);
        if (category == null)
        {
            return NotFound();
        }

        Category? parentCategory = null;
        if (updateCategory.ParentCategoryId.HasValue)
        {
            parentCategory = await _categoryRepository.GetByIdAsync(updateCategory.ParentCategoryId.Value);
            if (parentCategory == null)
            {
                return NotFound("Parent category doesn't exist.");
            }
        }

        category.UpdateName(updateCategory.Name);
        category.UpdateImage(updateCategory.Image);
        category.UpdateParentCategory(parentCategory);

        await _categoryRepository.UpdateAsync(category, cancellationToken);

        return Ok(category);
    }
}
