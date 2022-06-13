using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetMP.Catalog.Infrastructure.Data.Config;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnType("UNIQUEIDENTIFIER");

        builder
            .HasOne(c => c.ParentCategory)
            .WithMany(c => c.ChildCategories);

        builder
            .HasMany(c => c.Items)
            .WithOne(i => i.Category);

        builder.Property(c => c.Name)
            .IsRequired();
    }
}
