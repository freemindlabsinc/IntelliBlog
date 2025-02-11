﻿using Microsoft.Extensions.DependencyInjection;
using Blogging.Infrastructure.Data;

namespace Blogging.IntegrationTests.Data;

public class DbContextFixture : FixtureBase, IDisposable
{
    public DbContextFixture() : base() { }

    public void Dispose()
    {
        // Clean up the database
    }   

    public BloggingDbContext GetDbContext() => GetServiceProvider().GetService<BloggingDbContext>()!;
}
