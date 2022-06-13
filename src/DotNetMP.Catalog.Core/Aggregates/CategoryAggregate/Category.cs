using Ardalis.GuardClauses;
using DotNetMP.Catalog.Core.Aggregates.ItemAggregate;
using DotNetMP.SharedKernel;
using DotNetMP.SharedKernel.Interfaces;

namespace DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;

public class Category : EntityBase, IAggregateRoot
{
    private List<Category> _childCategories = new List<Category>();
    private List<Item> _items = new List<Item>();

    public string Name { get; private set; } = null!;
    public string? Image { get; private set; }
    public Category? ParentCategory { get; private set; }
    public Guid? ParentCategoryId { get; private set; }
    public IEnumerable<Category> ChildCategories => _childCategories.AsReadOnly();
    public IEnumerable<Item> Items => _items.AsReadOnly();

    protected Category() { }

    public Category(string name, string? image = null, Category? parentCategory = null)
    {
        Name = Guard.Against.NullOrWhiteSpace(name);
        Image = image;
        ParentCategory = parentCategory;
    }

    public void UpdateName(string name)
    {
        Name = Guard.Against.NullOrWhiteSpace(name);
    }

    public void UpdateImage(string? image)
    {
        Image = image;
    }

    public void UpdateParentCategory(Category? category)
    {
        ParentCategory = category;
    }
}
