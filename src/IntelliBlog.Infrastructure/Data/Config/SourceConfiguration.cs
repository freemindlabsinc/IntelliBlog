using IntelliBlog.Domain.Articles;
using IntelliBlog.Domain.Sources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelliBlog.Infrastructure.Data.Config;

public partial class ArticleSourceConfiguration : IEntityTypeConfiguration<ArticleSource>
{
    public void Configure(EntityTypeBuilder<ArticleSource> builder)
    {        
        builder.HasKey(articleSource => new { articleSource.ArticleId, articleSource.SourceId });

        builder.Property(asrc => asrc.ArticleId)
               .HasConversion(id => id.Value, value => new(value));

        builder.Property(asrc => asrc.SourceId)
               .HasConversion(id => id.Value, value => new(value));

        //builder.HasOne(articleSource => articleSource.Article)
        //    .WithMany(article => article.Sources)
        //    .HasForeignKey(articleSource => articleSource.ArticleId);
        //
        //builder.HasOne(articleSource => articleSource.Source)
        //    .WithMany(source => source.Articles)
        //    .HasForeignKey(articleSource => articleSource.SourceId);
    }
}

public partial class ArticleConfiguration
{
    public class SourceConfiguration : IEntityTypeConfiguration<Source>
    {
        public void Configure(EntityTypeBuilder<Source> builder)
        {
            builder
                .Property(source => source.Id)
                .ValueGeneratedOnAdd()
                .HasConversion(id => id.Value, value => new(value));

            builder.Property(p => p.Name)
                .HasMaxLength(DataSchemaConstants.DEFAULT_SOURCE_NAME_LENGTH)
                .IsRequired();

            builder.Property(p => p.URL)
                .HasMaxLength(DataSchemaConstants.DEFAULT_URL_LENGTH);

            builder.Property(p => p.Notes)
                .HasMaxLength(-1);

            //builder.OwnsMany(p => p.Articles, articles =>
            //{
            //    articles.Property(article => article.Id)
            //        .ValueGeneratedOnAdd()
            //        .HasConversion(id => id.Value, value => new ArticleId(value));
            //});
        }
    }
}
