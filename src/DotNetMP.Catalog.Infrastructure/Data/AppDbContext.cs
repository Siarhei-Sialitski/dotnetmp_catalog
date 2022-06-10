using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;
using DotNetMP.Catalog.Core.Aggregates.ItemAggregate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DotNetMP.Catalog.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
    { }

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Item> Items => Set<Item>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
