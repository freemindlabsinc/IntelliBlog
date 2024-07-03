using IntelliBlog.Domain.Blogs;

namespace IntelliBlog.Infrastructure.Data.Config;

public partial class BlogArticleConfiguration : IEntityTypeConfiguration<BlogArticle>
{
    public void Configure(EntityTypeBuilder<BlogArticle> builder)
    {
        builder
            .Property(tag => tag.Id)
            .ValueGeneratedOnAdd();
    }
}
