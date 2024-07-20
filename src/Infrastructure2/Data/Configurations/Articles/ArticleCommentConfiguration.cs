using Blogging.Domain.Aggregates;
using Blogging.Domain.Aggregates.Articles;

namespace Blogging.Infrastructure.Data.Config.Articles;

public class ArticleCommentConfiguration : IEntityTypeConfiguration<ArticleComment>
{
    public void Configure(EntityTypeBuilder<ArticleComment> builder)
    {
        builder.ToTable(nameof(ArticleComment) + "s");
        
        builder
            .Property(p => p.Text)
            .IsRequired();

    }
}
