namespace Infrastructure2.Data.Configurations;

public partial class PostSourceConfiguration : IEntityTypeConfiguration<PostSource>
{
    public void Configure(EntityTypeBuilder<PostSource> builder)
    {
        builder.ToTable(nameof(PostSource) + "s");

        builder.HasOne<Source>()
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(articleSource => articleSource.SourceId);

        //builder
        //    .Property(tag => tag.ArticleId)
        //    .HasConversion(id => id.Value, value => new ArticleId(value));

        //builder
        //    .Property(tag => tag.SourceId)
        //    .HasConversion(id => id.Value, value => new SourceId(value));
    }
}
