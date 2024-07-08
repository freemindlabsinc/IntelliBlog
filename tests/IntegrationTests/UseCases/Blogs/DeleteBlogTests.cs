using System.Configuration;
using System.Security.Permissions;
using Blogging.Application.UseCases.Blogs.Create;
using Blogging.Application.UseCases.Blogs.Delete;
using MediatR;
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

        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().HaveCount(1); // Blog not found
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
