using IntelliBlog.Domain.Articles;
using IntelliBlog.Domain.Blogs;

namespace IntelliBlog.Infrastructure.Data.Config;

public partial class BlogArticleConfiguration : IEntityTypeConfiguration<BlogArticle>
{
    public void Configure(EntityTypeBuilder<BlogArticle> builder)
    {
        builder.HasKey(blogArticle
            => new { blogArticle.ArticleId, blogArticle.BlogId });


        builder
            .Property(tag => tag.BlogId)
            .HasConversion(id => id.Value, value => new BlogId(value));

        builder
            .Property(tag => tag.ArticleId)
            .HasConversion(id => id.Value, value => new ArticleId(value));
    }
}
