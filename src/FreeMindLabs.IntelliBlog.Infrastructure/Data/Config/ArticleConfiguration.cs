using System.Reflection.Emit;
using FreeMindLabs.IntelliBlog.Core.Domain.Article;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreeMindLabs.IntelliBlog.Infrastructure.Data.Config;

public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder
            .Property(article => article.Id)
            .ValueGeneratedOnAdd()
            .HasConversion(id => id.Value, value => new(value));

        builder.Property(p => p.Title)
            .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
            .IsRequired();

        //builder.OwnsMany(builder => builder.Tags, x =>
        //{
        //    x.Property(p => p.Value)
        //    .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
        //    .IsRequired();
        //});
    }
}
