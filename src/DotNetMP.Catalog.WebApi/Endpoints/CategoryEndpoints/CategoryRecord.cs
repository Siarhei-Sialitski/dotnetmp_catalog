namespace DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints;

public record CategoryRecord(Guid id, string name, string? image, Guid? parentCategoryId);
