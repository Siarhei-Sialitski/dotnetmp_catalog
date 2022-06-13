namespace DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.Add;

public class UpdateCategoryDto
{
    public string Name { get; set; } = null!;
    public string? Image { get; set; }
    public Guid? ParentCategoryId { get; set; }
}
