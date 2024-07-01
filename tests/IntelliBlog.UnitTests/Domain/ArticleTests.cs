using FluentAssertions;
using IntelliBlog.Domain.Article;

namespace IntelliBlog.UnitTests.Domain;

public class ArticleTests
{
    [Fact]
    public void CreateArticle()
    {
        const string title = "Test Title";
        var article = Article.CreateNew(title);

        article.Title.Should().Be(title);
        article.Description.Should().BeNull();
        article.Text.Should().BeNull();

        article.Tags.Should().BeEmpty();
        article.Sources.Should().BeEmpty();
    }

    [Fact]
    public void CreateArticle_WithTextAndDescription()
    {
        const string title = "Test Title";
        const string description = "Test Description";
        const string text = "Test Text";

        var article = Article.CreateNew(title, description, text);

        article.Title.Should().Be(title);
        article.Description.Should().Be(description);
        article.Text.Should().Be(text);

        article.Tags.Should().BeEmpty();
        article.Sources.Should().BeEmpty();
    }

    [Fact]
    public void CreateArticle_WithTags()
    {
        const string title = "Test Title";
        const string tag1 = "Tag 1";
        const string tag2 = "Tag 2";

        var article = Article.CreateNew(title);

        article.AddTags(tag1, tag2);

        article.Tags.Should().HaveCount(2);
        article.Tags[0].Name.Should().Be(tag1);
        article.Tags[1].Name.Should().Be(tag2);
    }

    [Fact]
    public void CreateArticle_WithSources()
    {
        const string title = "Test Title";
        const string source1 = "Source 1";
        const string source2 = "Source 2";

        var article = Article.CreateNew(title);
        article.Sources.Should().BeEmpty();

        article.AddSources(source1, source2);

        article.Sources.Should().HaveCount(2);
        article.Sources[0].Name.Should().Be(source1);
        article.Sources[1].Name.Should().Be(source2);
    }

    [Fact]
    public void CreateArticle_WithEmptyTitle()
    {
        Action action = () => Article.CreateNew(string.Empty);
        
        action.Should().Throw<ArgumentException>();

    }

    [Fact]
    public void CreateArticle_WithEmptySources_ShouldFail()
    {
        var article = Article.CreateNew("Test");
        
        Action action = () => article.AddSources("");

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void CreateArticle_WithEmptyTags_ShouldFail()
    {
        var article = Article.CreateNew("Test");

        Action action = () => article.AddTags("");

        action.Should().Throw<ArgumentException>();
    }
}
