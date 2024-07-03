using IntelliBlog.Domain.Articles;

namespace IntelliBlog.Infrastructure.Data.Config;

public partial class ArticleSourceConfiguration : IEntityTypeConfiguration<ArticleSource>
{
    public void Configure(EntityTypeBuilder<ArticleSource> builder)
    {
        builder
            .Property(tag => tag.Id)
            .ValueGeneratedOnAdd();        
    }
}
