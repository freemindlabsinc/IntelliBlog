using IntelliBlog.Domain;
using IntelliBlog.Domain.Articles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelliBlog.Infrastructure.Data.Config;

public partial class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.Property(p => p.Created)
            .HasDefaultValueSql("GETUTCDATE()");

        builder
            .Property(article => article.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEXT VALUE FOR Article_seq")
            .HasConversion(id => id.Value, value => new(value));

        builder.Property(p => p.Title)
            .HasMaxLength(DataSchemaConstants.DEFAULT_TITLE_LENGTH);
            //.IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(DataSchemaConstants.DEFAULT_DESCRIPTION_LENGTH);

        builder.Property(p => p.Text)
            .HasMaxLength(-1);
    }
}
