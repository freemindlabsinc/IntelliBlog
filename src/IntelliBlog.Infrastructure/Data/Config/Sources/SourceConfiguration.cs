﻿using IntelliBlog.Domain.Sources;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IntelliBlog.Domain.Blogs;

namespace IntelliBlog.Infrastructure.Data.Config.Sources;

public class SourceConfiguration : IEntityTypeConfiguration<Source>
{
    public void Configure(EntityTypeBuilder<Source> builder)
    {
        builder
            .Property(source => source.Id)
            .ValueGeneratedOnAdd()
            .HasConversion(id => id.Value, value => new(value));

        builder.HasOne<Blog>()
               .WithMany()
               .HasForeignKey(p => p.BlogId);

        builder.Property(p => p.BlogId)
            .HasConversion(new ValueConverter<BlogId, int>(id => id.Value, value => new(value)));

        builder.Property(p => p.Name)
            .HasMaxLength(DataSchemaConstants.DEFAULT_SOURCE_NAME_LENGTH)
            .IsRequired();

        builder.Property(p => p.Url)
            .HasMaxLength(DataSchemaConstants.DEFAULT_URL_LENGTH);

        builder.Property(p => p.Description)
            .HasMaxLength(-1);
    }
}
