namespace Infrastructure2.Data.Configurations;

public class SourceConfiguration : IEntityTypeConfiguration<Source>
{
    public void Configure(EntityTypeBuilder<Source> builder)
    {
        // Common
        builder.AddSequenceForId<Source, int>();

        builder.AddTrackedEntityConfiguration<Source, int>();

        builder.HasOne<Blog>()
               .WithMany()
               .HasForeignKey(p => p.BlogId);

        //builder.Property(p => p.BlogId)
        //    .HasConversion(new ValueConverter<BlogId, int>(id => id.Value, value => new(value)));

        builder.Property(p => p.Name)
            .HasMaxLength(DataSchemaConstants.DEFAULT_SOURCE_NAME_LENGTH)
            .IsRequired();

        builder.Property(p => p.Url)
            .HasMaxLength(DataSchemaConstants.DEFAULT_URL_LENGTH);

        builder.Property(p => p.Description)
            .HasMaxLength(-1);
    }
}
