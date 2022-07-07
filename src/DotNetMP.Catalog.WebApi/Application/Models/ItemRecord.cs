namespace DotNetMP.Catalog.WebApi.Application.Models;

public record ItemRecord(Guid Id, Guid CategoryId, string Name, decimal Price, int Amount, string? Description, string? Image);
