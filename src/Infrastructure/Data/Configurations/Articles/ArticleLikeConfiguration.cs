using Blogging.Domain.Aggregates;
using Blogging.Domain.Aggregates.Articles;

namespace Blogging.Infrastructure.Data.Config.Articles;

public partial class ArticleLikeConfiguration : IEntityTypeConfiguration<ArticleLike>
{
    public void Configure(EntityTypeBuilder<ArticleLike> builder)
    {
        builder.ToTable(nameof(ArticleLike) + "s");

        builder
            .Property(like => like.ArticleId)
            .HasConversion(id => id.Value, value => new ArticleId(value));
        // TODO: try using implicit ops

        builder
            .Property(like => like.LikedBy)
            .HasMaxLength(DataSchemaConstants.DEFAULT_IDENTITY_ID);
    }
}
