namespace Infrastructure2.Data.Configurations;

public class PostCommentLikeConfiguration : IEntityTypeConfiguration<PostCommentLike>
{
    public void Configure(EntityTypeBuilder<PostCommentLike> builder)
    {
        builder.ToTable(nameof(PostCommentLike) + "s");

    }
}
