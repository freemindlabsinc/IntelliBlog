namespace Infrastructure2.Data.Configurations;

public partial class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        // Common
        builder.AddSequenceForId<Post, int>();

        builder.AddTrackedEntityConfiguration<Post, int>();

        // Entity
        builder.HasOne<Blog>()
               .WithMany()
               .HasForeignKey(p => p.BlogId);

        //builder.Property(p => p.BlogId)
        //       .HasConversion(new ValueConverter<BlogId, int>(id => id.Value, value => new(value)));

        builder.Property(p => p.Title)
               .HasMaxLength(DataSchemaConstants.DEFAULT_TITLE_LENGTH);
        //.IsRequired();

        builder.Property(p => p.Description)
               .HasMaxLength(DataSchemaConstants.DEFAULT_DESCRIPTION_LENGTH);

        builder.Property(p => p.Text)
               .HasMaxLength(-1);
    }
}
