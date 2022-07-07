namespace DotNetMP.Catalog.WebApi.Application.Models;

public record ItemRecord(Guid id, Guid categoryId, string name, decimal price, int amount, string? description, string? image);
