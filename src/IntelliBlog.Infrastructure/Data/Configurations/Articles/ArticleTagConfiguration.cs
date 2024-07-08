using Blogging.Domain.Aggregates.Articles;

namespace Blogging.Infrastructure.Data.Config.Articles;

public class ArticleTagConfiguration : IEntityTypeConfiguration<ArticleTag>
{
    public void Configure(EntityTypeBuilder<ArticleTag> builder)
    {
        builder.ToTable(nameof(ArticleTag) + "s");

        // Entity
        builder.Property(p => p.Name)
            .HasMaxLength(DataSchemaConstants.DEFAULT_TAG_NAME_LENGTH)
            .IsRequired();

    }
}
