using Microsoft.AspNetCore.Mvc;

namespace DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.Add;

public class AddCategoryRequest
{
    public const string Route = "/Categories";

    [FromBody]
    public UpdateCategoryDto Category { get; set; } = null!;
}
