using Ardalis.Result;
using Blogging.Application.Blogs.Commands;
using Blogging.Application.Posts.Commands;
using Xunit.Abstractions;

namespace Blogging.IntegrationTests.UseCases.Posts;

public partial class CreatePostTests : IClassFixture<UnitOfWorkFixture>
{
    readonly UnitOfWorkFixture _fixture;

    public CreatePostTests(UnitOfWorkFixture fixture, ITestOutputHelper outputHelper)
        : base()
    {
        _fixture = fixture;
        _fixture.SetTestOutputHelper(outputHelper);
    }

    Task<Result<int>> CreateBlogAsync()
    {
        var cmd = new CreateBlogCommand("A test blog");
        return _fixture.Sender.Send(cmd);
    }

    [Fact]
    public async Task Can_create_valid_article()
    {
        var blogId = await CreateBlogAsync();

        var cmd2 = new CreatePostCommand(blogId, "A valid article", "A valid description", "A valid text");
        var result = await _fixture.Sender.Send(cmd2);




        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeGreaterThan(0);

    }
}
