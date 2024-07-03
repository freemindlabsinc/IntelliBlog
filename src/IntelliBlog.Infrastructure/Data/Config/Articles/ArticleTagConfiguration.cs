using IntelliBlog.Domain;
using IntelliBlog.Domain.Articles;
using IntelliBlog.Domain.Blogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelliBlog.Infrastructure.Data.Config.Articles;

public class ArticleTagConfiguration : IEntityTypeConfiguration<ArticleTag>
{
    public void Configure(EntityTypeBuilder<ArticleTag> builder)
    {
        // Common
        builder.AddSequenceForId<ArticleTag, TagId>()
               .HasConversion(id => id.Value, value => new(value));

        // Entity
        builder.Property(p => p.Name)
            .HasMaxLength(DataSchemaConstants.DEFAULT_TAG_NAME_LENGTH)
            .IsRequired();

    }
}
