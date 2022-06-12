namespace DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.Update;

public class UpdateCategoryRequest
{
    public const string Route = "/Categories";

    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Image { get; set; }
    public Guid? ParentCategoryId { get; set; }
}
