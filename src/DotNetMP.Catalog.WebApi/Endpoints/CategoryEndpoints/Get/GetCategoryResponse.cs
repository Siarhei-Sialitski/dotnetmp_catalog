namespace DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.Get;

public class GetCategoryResponse
{
    public IList<CategoryRecord> Categories { get; set; } = null!;
}
