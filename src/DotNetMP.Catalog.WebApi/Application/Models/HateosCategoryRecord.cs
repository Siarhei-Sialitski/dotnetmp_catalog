using DotNetMP.Catalog.WebApi.Hateos;

namespace DotNetMP.Catalog.WebApi.Application.Models;

public record HateosCategoryRecord(Guid Id, string Name, string? Image, Guid? ParentCategoryId, List<Link> Links);
