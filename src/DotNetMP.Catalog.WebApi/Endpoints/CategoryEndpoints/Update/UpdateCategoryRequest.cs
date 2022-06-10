using DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.Update;

public class UpdateCategoryRequest
{
    public const string Route = "/Categories";

    [Required]
    [FromBody]
    public UpdateCategoryViewModel Category { get; set; } = null!;
}
