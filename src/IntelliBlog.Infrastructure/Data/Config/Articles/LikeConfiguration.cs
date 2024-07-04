using IntelliBlog.Domain.Articles;

namespace IntelliBlog.Infrastructure.Data.Config.Articles;

public partial class LikeConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder
            .Property(like => like.Id)
            .HasConversion(id => id.Value, value => new LikeId(value));

        builder
            .Property(like => like.ArticleId)
            .HasConversion(id => id.Value, value => new ArticleId(value));

        builder
            .Property(like => like.LikedBy)
            .HasMaxLength(DataSchemaConstants.DEFAULT_IDENTITY_ID);
    }
}
