﻿using System.Reflection;
using Ardalis.SharedKernel;
using IntelliBlog.Domain.Articles;
using IntelliBlog.Domain.Sources;
using Microsoft.EntityFrameworkCore;

namespace IntelliBlog.Infrastructure.Data;
public class AppDbContext : DbContext
{
    private readonly IDomainEventDispatcher? _dispatcher;

    public AppDbContext(DbContextOptions<AppDbContext> options,
      IDomainEventDispatcher? dispatcher)
        : base(options)
    {
        _dispatcher = dispatcher;
    }

    public DbSet<Blog> Blogs => Set<Blog>();
    public DbSet<Article> Articles => Set<Article>();
    public DbSet<Source> Sources => Set<Source>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
                
        modelBuilder.HasSequence<int>("Article_seq")
            .StartsAt(0)
            .IncrementsBy(1);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        // ignore events if no dispatcher provided
        if (_dispatcher == null) return result;

        // dispatch events only if save was successful
        var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToArray();

        await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

        return result;
    }

    public override int SaveChanges() =>
          SaveChangesAsync().GetAwaiter().GetResult();
}
