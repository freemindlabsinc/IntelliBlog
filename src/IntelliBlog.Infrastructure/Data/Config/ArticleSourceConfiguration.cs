using IntelliBlog.Domain.Articles;
using IntelliBlog.Domain.Sources;

namespace IntelliBlog.Infrastructure.Data.Config;

public partial class ArticleSourceConfiguration : IEntityTypeConfiguration<ArticleSource>
{
    public void Configure(EntityTypeBuilder<ArticleSource> builder)
    {
        builder
            .Property(tag => tag.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(tag => tag.ArticleId)
            .HasConversion(id => id.Value, value => new ArticleId(value));

        builder
            .Property(tag => tag.SourceId)
            .HasConversion(id => id.Value, value => new SourceId(value));
    }
}
