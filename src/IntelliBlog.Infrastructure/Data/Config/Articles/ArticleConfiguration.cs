using IntelliBlog.Domain;
using IntelliBlog.Domain.Articles;
using IntelliBlog.Domain.Blogs;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IntelliBlog.Infrastructure.Data.Config.Articles;

public partial class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        // Common
        builder.AddSequenceForId<Article, ArticleId>()
               .HasConversion(id => id.Value, value => new(value));

        builder.AddTrackedEntityConfiguration<Article, ArticleId>();

        // Entity
        builder.HasOne<Blog>()
               .WithMany()
               .HasForeignKey(p => p.BlogId);

        builder.Property(p => p.BlogId)
               .HasConversion(new ValueConverter<BlogId, int>(id => id.Value, value => new(value)));

        builder.Property(p => p.Title)
               .HasMaxLength(DataSchemaConstants.DEFAULT_TITLE_LENGTH);
        //.IsRequired();

        builder.Property(p => p.Description)
               .HasMaxLength(DataSchemaConstants.DEFAULT_DESCRIPTION_LENGTH);

        builder.Property(p => p.Text)
               .HasMaxLength(-1);
    }
}
