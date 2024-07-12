using Blogging.Domain.Aggregates;
using Blogging.Domain.Aggregates.Blogs;

namespace Blogging.Infrastructure.Data.Config.Blogs;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        // Common
        builder.AddSequenceForId<Blog, int>();

        builder.AddTrackedEntityConfiguration<Blog, int>();

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
