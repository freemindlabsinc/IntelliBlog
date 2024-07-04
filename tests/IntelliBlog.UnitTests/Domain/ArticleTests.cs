using IntelliBlog.Domain.Articles;
using IntelliBlog.Domain;
using IntelliBlog.Domain.Sources;
using IntelliBlog.Domain.Blogs;

namespace IntelliBlog.UnitTests.Domain;

public class ArticleTests
{
    // We can only create articles for an existing blog.
    private Blog Blog => Blog.CreateNew("Fake Blog", id: 1);
    private Source Source1 => Source.CreateNew(Blog.Id, "Fake Blog", id: 100);
    private Source Source2 => Source.CreateNew(Blog.Id, "Fake Blog", id: 101);

    Article GetArticle() => Article.CreateNew(Blog.Id, "Test Title");

    [Fact]
    public void Can_create_new_article()
    {        
        const string title = "Test Title";
        const string description = "Test Description";
        const string text = "Test Text";
        var article = Article.CreateNew(Blog.Id, title, description, text);

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
        var article = GetArticle();

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
        var article = GetArticle();

        article.AddSource(Source1.Id);
        article.AddSource(Source2.Id);
        
        article.Sources.Should().HaveCount(2);
        var arr = article.Sources.ToArray();
        arr[0].ArticleId.Should().Be(article.Id);
        arr[0].SourceId.Should().Be(Source1.Id);
        arr[1].ArticleId.Should().Be(article.Id);
        arr[1].SourceId.Should().Be(Source2.Id);
    }

    [Fact]
    public void Cannot_add_duplicate_like()
    {
        var article = GetArticle();
        
        article.Like("user1");
        article.Like("user2");
        article.Like("user1");

        article.Likes.Should().HaveCount(2);
    }

    [Fact]
    public void Cannot_create_article_with_empty_title()
    {
        Action action = () => Article.CreateNew(Blog.Id, string.Empty);
        
        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Cannot_create_article_with_empty_tags()
    { 
        var article = GetArticle();

        Action action = () => article.AddTags("");

        action.Should().Throw<ArgumentException>();
    }
}
