using Microsoft.AspNetCore.Mvc;

namespace DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.Update;

public class UpdateCategoryRequest
{
    public const string Route = "/Categories";

    [FromBody]
    public UpdateCategoryDto Category { get; set; } = null!;
}
