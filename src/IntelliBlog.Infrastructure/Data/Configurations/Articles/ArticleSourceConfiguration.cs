using IntelliBlog.Domain.Aggregates;
using IntelliBlog.Domain.Aggregates.Articles;
using IntelliBlog.Domain.Aggregates.Sources;

namespace IntelliBlog.Infrastructure.Data.Config.Articles;

public partial class ArticleSourceConfiguration : IEntityTypeConfiguration<ArticleSource>
{
    public void Configure(EntityTypeBuilder<ArticleSource> builder)
    {
        builder.ToTable(nameof(ArticleSource) + "s");

        builder.HasOne<Source>()
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(articleSource => articleSource.SourceId);            

        builder
            .Property(tag => tag.ArticleId)
            .HasConversion(id => id.Value, value => new ArticleId(value));

        builder
            .Property(tag => tag.SourceId)
            .HasConversion(id => id.Value, value => new SourceId(value));
    }
}
