﻿using DotNetMP.Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DotNetMP.Catalog.Infrastructure;

internal class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    private IConfigurationRoot _configuration;

    public AppDbContextFactory()
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        _configuration = builder.Build();
    }

    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"), m => { m.EnableRetryOnFailure(); });

        return new AppDbContext(optionsBuilder.Options);
    }
}
