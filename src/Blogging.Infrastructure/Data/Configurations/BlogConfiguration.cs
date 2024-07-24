namespace Blogging.Infrastructure.Data.Configurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        // Common
        builder.AddSequenceForId<Blog, int>();


        builder.Property(p => p.CreatedBy)
               .HasMaxLength(DbSchemaConstants.DEFAULT_IDENTITY_ID)
               .IsRequired();

        builder.Property(p => p.CreatedOn)
               .IsRequired();

        builder.Property(p => p.LastModifiedBy)
               .HasMaxLength(DbSchemaConstants.DEFAULT_IDENTITY_ID);

        builder.Property(p => p.LastModifiedOn);

        // Entity
        builder.Property(p => p.Name)
               .HasMaxLength(DbSchemaConstants.DEFAULT_BLOG_NAME_LENGTH)
               .IsRequired();

        builder.Property(p => p.Description)
               .HasMaxLength(DbSchemaConstants.NO_MAX_LENGTH);

        builder.Property(p => p.Notes)
               .HasMaxLength(DbSchemaConstants.NO_MAX_LENGTH);

        builder.Property(p => p.Image)
            .HasMaxLength(DbSchemaConstants.DEFAULT_URL_LENGTH);

        
    }
}
