using IntelliBlog.Domain.Aggregates.Articles;
using IntelliBlog.Domain.Aggregates.Blogs;
using IntelliBlog.Domain.Aggregates.Sources;

namespace IntelliBlog.UnitTests.Domain;

public class ArticleTests
{
    Article NewArticle() => Article.CreateNew(1, "Test Title");

    [Fact]
    public void Can_create_new_article()
    {        
        const string title = "Test Title";
        const string description = "Test Description";
        const string text = "Test Text";
        var article = Article.CreateNew(1, title, description, text);

        article.Title.Should().Be(title);
        article.Description.Should().Be(description);
        article.Text.Should().Be(text);

        article.Tags.Should().BeEmpty();
        article.Sources.Should().BeEmpty();
        article.Likes.Should().BeEmpty();
    }   

    [Fact]
    public void Can_add_tags()
    {
        var article = NewArticle();

        const string tag1 = "Tag 1";
        const string tag2 = "Tag 2";

        article.AddTags(tag1, tag2);

        article.Tags.Should().HaveCount(2);
        article.Tags.First().Name.Should().Be(tag1);
        article.Tags.Last().Name.Should().Be(tag2);
    }

    [Fact]
    public void Can_add_sources()
    {                
        var article = NewArticle();

        var source1 = 100;
        var source2 = 101;

        article.AddSource(source1);
        article.AddSource(source2);
        
        article.Sources.Should().HaveCount(2);
        var arr = article.Sources.ToArray();
        arr[0].ArticleId.Should().Be(article.Id);
        arr[0].SourceId.Value.Should().Be(source1);
        arr[1].ArticleId.Should().Be(article.Id);
        arr[1].SourceId.Value.Should().Be(source2);
    }

    [Fact]
    public void Cannot_add_duplicate_like()
    {
        var article = NewArticle();
        
        article.Like("user1");
        article.Like("user2");
        article.Like("user1");

        article.Likes.Should().HaveCount(2);
    }

    [Fact]
    public void Cannot_create_article_with_empty_title()
    {
        Action action = () => Article.CreateNew(1, string.Empty);
        
        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Cannot_create_article_with_empty_tags()
    { 
        var article = NewArticle();

        Action action = () => article.AddTags("");

        action.Should().Throw<ArgumentException>();
    }
}
