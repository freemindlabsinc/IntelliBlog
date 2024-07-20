using Blogging.Domain;

namespace Blogging.UnitTests.Domain;

public class BlogTests
{
    [Fact]
    public void Can_create_new_blog()
    {
        const string name = "Test Blog";
        const string description = "Test Description";
        const string image = "Test Image";
        const string notes = "Test Notes";

        var blog = new Blog(
            name: name,
            description: description,
            image: image,            
            notes: notes);

        blog.Name.Should().Be(name);
        blog.Description.Should().Be(description);
        blog.Image.Should().Be(image);
        blog.IsOnline.Should().Be(false);
        blog.Notes.Should().Be(notes);       
    }    
}
