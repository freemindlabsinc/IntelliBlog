using Blogging.Domain;

namespace Blogging.UnitTests.Domain;

public class PostTests
{
    Post NewPost() => new Post(1, "Test Title");

    [Fact]
    public void Can_create_new_post()
    {        
        const string title = "Test Title";
        const string description = "Test Description";
        const string text = "Test Text";
        var article = new Post(1, title, description, text);

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
        var article = new Post(1, "Test Title");

        const string tag1 = "Tag 1";
        const string tag2 = "Tag 2";

        article.AddTags(tag1, tag2);

        article.Tags.Should().HaveCount(2);
        article.Tags.First().Should().Be(tag1);
        article.Tags.Last().Should().Be(tag2);
    }

    [Fact]
    public void Can_add_sources()
    {                
        var article = NewPost();

        var source1 = 100;
        var source2 = 101;

        article.AddSources(source1);
        article.AddSources(source2);
        
        article.Sources.Should().HaveCount(2);
        var arr = article.Sources.ToArray();
        arr[0].PostId.Should().Be(article.Id);
        arr[0].SourceId.Should().Be(source1);
        arr[1].PostId.Should().Be(article.Id);
        arr[1].SourceId.Should().Be(source2);
    }

    [Fact]
    public void Cannot_add_duplicate_like()
    {
        var article = NewPost();
        
        article.Like("user1");
        article.Like("user2");
        article.Like("user1");

        article.Likes.Should().HaveCount(2);
    }

    [Fact]
    public void Cannot_create_article_with_empty_title()
    {
        Action action = () => new Post(1, string.Empty);
        
        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Cannot_create_post_with_empty_tags()
    { 
        var article = NewPost();

        Action action = () => article.AddTags("");

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Can_add_comment()
    {
        var article = NewPost();
        
        var comment1 = new PostComment(article.Id, "Comment 1", "user1");
        

    }
}
