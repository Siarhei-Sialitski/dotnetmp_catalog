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
            .HasOne<Category>()
            .WithMany()
            .HasForeignKey(c => c.ParentCategoryId);

        builder.Property(c => c.Name)
            .IsRequired();
    }
}
