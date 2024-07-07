﻿namespace IntelliBlog.Infrastructure.Data.Config;

public static class EntityConfigurationExtensions
{
    public static PropertyBuilder<TId> AddSequenceForId<TEntity, TId>(this EntityTypeBuilder<TEntity> builder)
        where TId : struct, IEquatable<TId>
        where TEntity : Entity<TId>
    {
        return builder.Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql($"NEXT VALUE FOR {AppDbContext.GlobalSequenceName}");            
    }

    public static void AddTrackedEntityConfiguration<TEntity, TId>(this EntityTypeBuilder<TEntity> builder)
        where TId : struct, IEquatable<TId>
        where TEntity : TrackedEntity<TId>
    {
        builder.Property(p => p.Created)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("GETUTCDATE()");

        //builder.Property(p => p.LastModified)
        //    .ValueGeneratedOnUpdate()
        //    .HasDefaultValueSql("GETUTCDATE()");
    }
}