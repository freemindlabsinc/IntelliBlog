using Blogging.Domain.Aggregates.Sources;

namespace Blogging.Infrastructure.Data.Config.Sources;

public partial class SourceTagConfiguration : IEntityTypeConfiguration<SourceTag>
{
    public void Configure(EntityTypeBuilder<SourceTag> builder)
    {
        builder.ToTable(nameof(SourceTag) + "s");

        builder.Property(p => p.Name)
            .HasMaxLength(DataSchemaConstants.DEFAULT_TAG_NAME_LENGTH)
            .IsRequired();
    }
}
