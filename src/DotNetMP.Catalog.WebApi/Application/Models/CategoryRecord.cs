namespace DotNetMP.Catalog.WebApi.Application.Models;

public record CategoryRecord(Guid id, string name, string? image, Guid? parentCategoryId);
