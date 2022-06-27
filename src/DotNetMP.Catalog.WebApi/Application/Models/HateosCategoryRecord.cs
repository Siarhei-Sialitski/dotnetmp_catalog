using DotNetMP.Catalog.WebApi.Hateos;

namespace DotNetMP.Catalog.WebApi.Application.Models;

public record HateosCategoryRecord(Guid id, string name, string? image, Guid? parentCategoryId, List<Link> links);
