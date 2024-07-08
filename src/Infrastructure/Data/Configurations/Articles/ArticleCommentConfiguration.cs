using Blogging.Domain.Aggregates;
using Blogging.Domain.Aggregates.Articles;

namespace Blogging.Infrastructure.Data.Config.Articles;

public class ArticleCommentConfiguration : IEntityTypeConfiguration<ArticleComment>
{
    public void Configure(EntityTypeBuilder<ArticleComment> builder)
    {
        builder.ToTable(nameof(ArticleComment) + "s");

        // Entity
        builder.Property(p => p.ArticleId)
               .HasConversion(id => id.Value, value => new ArticleId(value));

        //builder.Property(p => p.ParentId)
        //       .HasConversion(id => id ?? id.Value.Value : 0, value => new CommentId(value));

        builder
            .Property(p => p.Text)
            .IsRequired();

    }
}
