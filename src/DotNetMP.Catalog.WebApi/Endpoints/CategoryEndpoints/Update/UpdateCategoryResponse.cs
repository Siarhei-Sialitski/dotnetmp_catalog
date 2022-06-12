namespace DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.Update;

public class UpdateCategoryResponse
{
    public UpdateCategoryResponse(CategoryRecord category)
    {
        Category = category;
    }

    public CategoryRecord Category { get; set; }
}
