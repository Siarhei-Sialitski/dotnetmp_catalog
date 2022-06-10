using DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.ViewModels.Category;

namespace DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.Get;

public class GetCategoryResponse
{
    public IList<ReadCategoryViewModel> Categories { get; set; } = null!;
}
