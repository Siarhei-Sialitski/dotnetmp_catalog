namespace DotNetMP.Catalog.WebApi.Application.Models;

public record CategoryRecord(Guid Id, string Name, string? Image, Guid? ParentCategoryId);
