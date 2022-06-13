using Ardalis.GuardClauses;
using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;
using DotNetMP.SharedKernel;
using DotNetMP.SharedKernel.Interfaces;

namespace DotNetMP.Catalog.Core.Aggregates.ItemAggregate;

public class Item : EntityBase, IAggregateRoot
{
    public string Name { get; private set; } = null!;
    public string? Description { get; private set; }
    public string? Image { get; private set; }
    public decimal Price { get; private set; }
    public int Amount { get; private set; }
    public Category Category { get; private set; } = null!;
    public Guid CategoryId { get; private set; }

    protected Item() { }

    public Item(Category category, string name, decimal price, int amount, string? description = null, string? image = null)
    {
        Category = Guard.Against.Null(category);
        Name = Guard.Against.NullOrWhiteSpace(name);
        Description = description;
        Image = image;
        Price = Guard.Against.NegativeOrZero(price);
        Amount = Guard.Against.NegativeOrZero(amount);
    }

    public void UpdateName(string name)
    {
        Name = Guard.Against.NullOrWhiteSpace(name);
    }

    public void UpdateDescription(string? description)
    {
        Description = description;
    }

    public void UpdatePrice(decimal price)
    {
        Price = Guard.Against.NegativeOrZero(price);
    }

    public void UpdateAmount(int amount)
    {
        Amount = Guard.Against.NegativeOrZero(amount);
    }

    public void UpdateImage(string? image)
    {
        Image = image;
    }

    public void UpdateCategory(Category category)
    {
        Category = Guard.Against.Null(category);
    }
}
