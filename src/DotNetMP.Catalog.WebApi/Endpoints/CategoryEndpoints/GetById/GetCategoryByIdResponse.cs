namespace DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.GetById;

public class GetCategoryByIdResponse
{
    public GetCategoryByIdResponse(CategoryRecord category)
    {
        Category = category;
    }

    public CategoryRecord Category { get; set; }
}
