using IntelliBlog.Domain.Articles;
using IntelliBlog.Domain.Blogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelliBlog.Infrastructure.Data.Config;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        // Common
        builder.AddSequenceForId<Blog, BlogId>()
               .HasConversion(id => id.Value, value => new(value));

        builder.AddTrackedEntityConfiguration<Blog, BlogId>();

        // Entity
        builder.Property(p => p.Name)
               .HasMaxLength(DataSchemaConstants.DEFAULT_BLOG_NAME_LENGTH)
               .IsRequired();

        builder.Property(p => p.Description)
               .HasMaxLength(DataSchemaConstants.NO_MAX_LENGTH);

        builder.Property(p => p.Notes)
               .HasMaxLength(DataSchemaConstants.NO_MAX_LENGTH);

        builder.Property(p => p.Image)
            .HasMaxLength(DataSchemaConstants.DEFAULT_URL_LENGTH);

        builder.Property(p => p.SmallImage)
            .HasMaxLength(DataSchemaConstants.DEFAULT_URL_LENGTH);
    }
}
