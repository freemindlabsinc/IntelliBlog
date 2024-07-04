using IntelliBlog.Domain.Blogs;
using IntelliBlog.Domain.Sources;

namespace IntelliBlog.UnitTests.Domain;

public class SourceTests
{
    private Blog Blog => Blog.CreateNew("Fake Blog", id: 1);

    [Fact]
    public void Can_create_new_source()
    {
        const string name = "Test Source";
        const string description = "Test Description";
        const string url = "http://test.com";
        
        var source = Source.CreateNew(
            blogId: Blog.Id,
            name: name,
            description: description,
            url: url);

        source.BlogId.Should().Be(Blog.Id);
        source.Name.Should().Be(name);
        source.Description.Should().Be(description);
        source.Url.Should().Be(url);        
    }
}
