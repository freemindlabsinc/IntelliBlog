using IntelliBlog.Domain.Articles;
using IntelliBlog.Domain.Sources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelliBlog.Infrastructure.Data.Config;

public class ArticleTagConfiguration : IEntityTypeConfiguration<ArticleTag>
{
    public void Configure(EntityTypeBuilder<ArticleTag> builder)
    {
        builder
            .Property(tag => tag.Id)
            .ValueGeneratedOnAdd()
            .HasConversion(id => id.Value, value => new(value));
        
        builder.Property(p => p.Name)
            .HasMaxLength(DataSchemaConstants.DEFAULT_TAG_NAME_LENGTH)
            .IsRequired();

    }  
}
