using DotNetMP.SharedKernel;
using DotNetMP.SharedKernel.Interfaces;

namespace DotNetMP.Catalog.Core.Aggregates.ItemAggregate;

public class Item : EntityBase, IAggregateRoot
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Image { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
    public Guid CategoryId { get; set; }

    protected Item()
    { }

    public Item(Guid categoryId, string name, decimal price, int amount, string? description = null, string? image = null)
    {
        CategoryId = categoryId;
        Name = name;
        Description = description;
        Image = image;
        Price = price;
        Amount = amount;
    }
}
