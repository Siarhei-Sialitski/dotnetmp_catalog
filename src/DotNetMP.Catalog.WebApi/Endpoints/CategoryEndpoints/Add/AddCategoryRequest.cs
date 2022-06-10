using DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.Add;

public class AddCategoryRequest
{
    public const string Route = "/Categories";

    [FromBody]
    public CategoryViewModel Category { get; set; } = null!;
}
