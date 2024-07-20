namespace Infrastructure2.Data.Configurations;

public class SourceLikeConfiguration : IEntityTypeConfiguration<SourceLike>
{
    public void Configure(EntityTypeBuilder<SourceLike> builder)
    {
        builder
            .Property(like => like.Id)
            .ValueGeneratedOnAdd();

        //builder.HasOne<Source>()
        //       .WithMany()
        //       .HasForeignKey(p => p.SourceId);
    }
}
