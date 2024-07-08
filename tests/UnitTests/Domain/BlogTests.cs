using Blogging.Domain.Aggregates.Blogs;

namespace Blogging.UnitTests.Domain;

public class BlogTests
{
    [Fact]
    public void Can_create_new_blog()
    {
        const string name = "Test Blog";
        const string description = "Test Description";
        const string smallImage = "Test Small Image";
        const string image = "Test Image";
        const string notes = "Test Notes";

        var blog = Blog.CreateNew(
            name: name,
            description: description,
            smallImage: smallImage,
            image: image,
            notes: notes);

        blog.Name.Should().Be(name);
        blog.Description.Should().Be(description);
        blog.SmallImage.Should().Be(smallImage);
        blog.Image.Should().Be(image);
        blog.IsPublished.Should().Be(false);
        blog.Notes.Should().Be(notes);       
    }    
}
