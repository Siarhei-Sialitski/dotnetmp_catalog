namespace DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.ViewModels.Item;

public class ItemViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Image { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
    public Guid CategoryId { get; set; }
}
