namespace Infrastructure2.Data.Configurations;

public class PostCommentConfiguration : IEntityTypeConfiguration<PostComment>
{
    public void Configure(EntityTypeBuilder<PostComment> builder)
    {
        builder.ToTable(nameof(PostComment) + "s");

        builder
            .Property(p => p.Text)
            .IsRequired();


        builder.HasOne<Post>()
               .WithMany()
               .HasForeignKey(p => p.PostId);
    }
}
