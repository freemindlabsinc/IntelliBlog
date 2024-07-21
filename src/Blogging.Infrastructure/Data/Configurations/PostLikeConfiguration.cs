namespace Blogging.Infrastructure.Data.Configurations;

public partial class PostLikeConfiguration : IEntityTypeConfiguration<PostLike>
{
    public void Configure(EntityTypeBuilder<PostLike> builder)
    {
        builder.ToTable(nameof(PostLike) + "s");

        //builder
        //    .Property(like => like.ArticleId)
        //    .HasConversion(id => id.Value, value => new ArticleId(value));
        // TODO: try using implicit ops

        builder
            .Property(like => like.LikedBy)
            .HasMaxLength(DbSchemaConstants.DEFAULT_IDENTITY_ID);
    }
}
