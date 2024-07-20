namespace Infrastructure2.Data.Configurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        // Common
        builder.AddSequenceForId<Blog, int>();

        builder.AddTrackedEntityConfiguration<Blog, int>();

        
        // Entity
        builder.Property(p => p.Name)
               .HasMaxLength(DataSchemaConstants.DEFAULT_BLOG_NAME_LENGTH)
               .IsRequired();

        builder.Property(p => p.Description)
               .HasMaxLength(DataSchemaConstants.NO_MAX_LENGTH);

        builder.Property(p => p.Notes)
               .HasMaxLength(DataSchemaConstants.NO_MAX_LENGTH);

        builder.Property(p => p.Image)
            .HasMaxLength(DataSchemaConstants.DEFAULT_URL_LENGTH);
    }
}
