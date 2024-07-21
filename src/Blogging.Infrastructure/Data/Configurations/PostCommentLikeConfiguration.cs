namespace Blogging.Infrastructure.Data.Configurations;

public class PostCommentLikeConfiguration : IEntityTypeConfiguration<PostCommentLike>
{
    public void Configure(EntityTypeBuilder<PostCommentLike> builder)
    {
        builder.ToTable(nameof(PostCommentLike) + "s");

    }
}
