using IntelliBlog.Domain.Articles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelliBlog.Infrastructure.Data.Config;

public partial class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder
            .Property(article => article.Id)
            .ValueGeneratedOnAdd()
            .HasConversion(id => id.Value, value => new(value));

        builder.Property(p => p.Title)
            .HasMaxLength(DataSchemaConstants.DEFAULT_TITLE_LENGTH)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(DataSchemaConstants.DEFAULT_DESCRIPTION_LENGTH);

        builder.Property(p => p.Text)
            .HasMaxLength(-1);

        builder.OwnsMany(p => p.Tags, tags =>
        {            
            tags.Property(tag => tag.Id)
                .ValueGeneratedOnAdd()
                .HasConversion(id => id.Value, value => new TagId(value));

            tags.Property(tag => tag.Name)
                .HasMaxLength(DataSchemaConstants.DEFAULT_TAG_NAME_LENGTH)
                .IsRequired();
        });        

        //builder.OwnsMany(p => p.Sources, sources =>
        //{
        //    sources.Property(src => src.Id)
        //        .ValueGeneratedOnAdd()
        //        .HasConversion(id => id.Value, value => new SourceId(value));
        //
        //    sources.Property(src => src.Name)
        //        .HasMaxLength(DataSchemaConstants.DEFAULT_SOURCE_NAME_LENGTH)
        //        .IsRequired();
        //
        //    sources.Property(src => src.URL)
        //        .HasMaxLength(DataSchemaConstants.DEFAULT_URL_LENGTH);
        //
        //    sources.Property(src => src.Notes)
        //        .HasMaxLength(-1);
        //});
    }
}
