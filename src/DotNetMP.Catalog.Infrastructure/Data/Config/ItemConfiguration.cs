using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;
using DotNetMP.Catalog.Core.Aggregates.ItemAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetMP.Catalog.Infrastructure.Data.Config;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnType("UNIQUEIDENTIFIER");

        builder.Property(i => i.Name)
            .IsRequired();

        builder.Property(i => i.Price)
            .IsRequired()
            .HasColumnType("money");

        builder.Property(i => i.Amount)
            .IsRequired();

        builder
            .HasOne<Category>()
            .WithMany()
            .HasForeignKey(i => i.CategoryId);

    }
}
