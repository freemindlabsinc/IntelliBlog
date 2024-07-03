using IntelliBlog.Domain.Articles;
using IntelliBlog.Domain.Blogs;
using IntelliBlog.Domain.Sources;

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
        article.Tags.First().Name.Should().Be(tag1);
        article.Tags.Last().Name.Should().Be(tag2);
    }

    [Fact]
    public void CreateArticle_WithSources()
    {
        const string title = "Test Title";
        
        var source1 = Source.CreateNew("Source 1");
        var source2 = Source.CreateNew("Source 2");
        
        var article = Article.CreateNew(title);
        article.Sources.Should().BeEmpty();
        
        var source = Source.CreateNew("Test Source");
        
        article.AddSources(source1.Id, source2.Id);
        
        article.Sources.Should().HaveCount(2);
        var arr = article.Sources.ToArray();
        arr[0].SourceId.Should().Be(source1);
        arr[1].SourceId.Should().Be(source2);
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
        throw new NotImplementedException();
        //var article = Article.CreateNew("Test");
        //
        //Action action = () => article.AddSources("");
        //
        //action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void CreateArticle_WithEmptyTags_ShouldFail()
    {
        var article = Article.CreateNew("Test");

        Action action = () => article.AddTags("");

        action.Should().Throw<ArgumentException>();
    }
}
