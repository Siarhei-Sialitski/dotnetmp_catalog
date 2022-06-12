namespace DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.Add;

public class AddCategoryResponse
{
    public AddCategoryResponse(CategoryRecord categoryRecord)
    {
        Category = categoryRecord;
    }
    public CategoryRecord Category { get; set; }
}
