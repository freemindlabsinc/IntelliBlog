using Application.Blogs.Commands.Create;
using Application.Blogs.Commands.Delete;
using Ardalis.Result;
using Xunit.Abstractions;

namespace Blogging.IntegrationTests.UseCases.Blogs;

public class DeleteBlogTests : IClassFixture<UnitOfWorkFixture>
{
    readonly UnitOfWorkFixture _fixture;
    
    public DeleteBlogTests(UnitOfWorkFixture fixture, ITestOutputHelper outputHelper)
        : base()
    {
        _fixture = fixture;
        _fixture.SetTestOutputHelper(outputHelper);
    }

    [Fact]
    public async Task Cannot_succeed_deleting_by_wrong_blog()
    {
        var cmd = new DeleteBlogCommand(1);
        var result = await _fixture.Sender.Send(cmd);

        result.IsNotFound();
    }

    [Fact]
    public async Task Can_delete_created_blog()
    {
        var newBlogId = await _fixture.Sender.Send(new CreateBlogCommand("A valid blog"));
        newBlogId.IsSuccess.Should().BeTrue();        

        var cmd = new DeleteBlogCommand(newBlogId);
        var result = await _fixture.Sender.Send(cmd);

        result.IsSuccess.Should().BeTrue();
    }
}
