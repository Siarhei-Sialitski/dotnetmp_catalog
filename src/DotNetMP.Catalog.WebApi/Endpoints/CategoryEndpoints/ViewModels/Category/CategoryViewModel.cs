namespace DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.ViewModels.Category;

public class CategoryViewModel
{
    public string Name { get; set; } = null!;
    public string? Image { get; set; }
    public Guid? ParentCategoryId { get; set; }
}
