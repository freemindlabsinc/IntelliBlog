using Blogging.Domain.Aggregates.Blogs;
using Blogging.Domain.Aggregates.Sources;

namespace Blogging.UnitTests.Domain;

public class SourceTests
{
    [Fact]
    public void Can_create_new_source()
    {
        const string name = "Test Source";
        const string description = "Test Description";
        const string url = "http://test.com";
        
        var source = Source.CreateNew(
            blogId: 101,
            name: name,
            description: description,
            url: url);

        source.BlogId.Value.Should().Be(101);
        source.Name.Should().Be(name);
        source.Description.Should().Be(description);
        source.Url.Should().Be(url);        
    }
}
