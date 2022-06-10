using DotNetMP.Catalog.Core.Aggregates.ItemAggregate;
using DotNetMP.SharedKernel;
using DotNetMP.SharedKernel.Interfaces;

namespace DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;

public class Category : EntityBase, IAggregateRoot
{
    public string Name { get; set; } = null!;
    public string? Image { get; set; }
    public Guid? ParentCategoryId { get; set; }

    protected Category()
    {

    }

    public Category(string name, string? image = null, Guid? parentCategoryId = null)
    {
        Name = name;
        Image = image;
        ParentCategoryId = parentCategoryId;
    }
}
