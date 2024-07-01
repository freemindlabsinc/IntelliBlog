using IntelliBlog.Domain.Articles;
using IntelliBlog.Domain.Sources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelliBlog.Infrastructure.Data.Config;

public partial class ArticleSourceConfiguration : IEntityTypeConfiguration<ArticleSource>
{
    public void Configure(EntityTypeBuilder<ArticleSource> builder)
    {
        builder
            .Property(tag => tag.Id)
            .ValueGeneratedOnAdd();
        //    .HasConversion(id => id.Value, value => new(value));

        //builder.Property(asrc => asrc.ArticleId)
        //       .HasConversion(id => id.Value, value => new(value));

        //builder.Property(asrc => asrc.SourceId)
        //       .HasConversion(id => id.Value, value => new(value));

        //builder.HasOne<Source>()
               //.WithMany()
               //.HasForeignKey(asrc => asrc.SourceId);

        //builder.HasOne<Article>()
               //.WithMany()
               //.HasForeignKey(asrc => asrc.ArticleId);
    }
}
