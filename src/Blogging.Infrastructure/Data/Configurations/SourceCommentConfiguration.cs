namespace Blogging.Infrastructure.Data.Configurations;

public class SourceCommentConfiguration : IEntityTypeConfiguration<SourceComment>
{
    public void Configure(EntityTypeBuilder<SourceComment> builder)
    {
        builder
            .Property(comment => comment.Id)
            .ValueGeneratedOnAdd();

        builder.HasOne<Source>()
               .WithMany()
               .HasForeignKey(p => p.SourceId);

    }
}
