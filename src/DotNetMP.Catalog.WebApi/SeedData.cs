using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;
using DotNetMP.Catalog.Core.Aggregates.ItemAggregate;
using DotNetMP.Catalog.Infrastructure.Data;

namespace DotNetMP.Catalog.WebApi;

public static class SeedDataManager
{
    public static IHost SeedData(this IHost webApp)
    {
        using (var scope = webApp.Services.CreateScope())
        {
            using var appContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            try
            {
                if (appContext.Categories.Any())
                {
                    return webApp;
                }
                PopulateTestData(appContext);
            }
            catch (Exception)
            {
                throw;
            }
        }
        return webApp;
    }

    public static void PopulateTestData(AppDbContext dbContext)
    {
        foreach (var c in dbContext.Categories)
        {
            dbContext.Remove(c);
        }
        foreach (var i in dbContext.Items)
        {
            dbContext.Remove(i);
        }
        dbContext.SaveChanges();

        var electronicsCategory = new Category("Electronics", null, null);
        dbContext.Categories.Add(electronicsCategory);

        var tvCategory = new Category("TV", null, electronicsCategory);
        dbContext.Categories.Add(tvCategory);

        var item = new Item(tvCategory, "Samsung", (decimal)12.4, 10, "Samsung TV");
        dbContext.Items.Add(item);
        dbContext.SaveChanges();
    }
}
