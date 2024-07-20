using Application.Articles.Commands.Create;
using Application.Blogs.Commands.Create;
using Ardalis.Result;
using Xunit.Abstractions;

namespace Blogging.IntegrationTests.UseCases.Articles;

public partial class CreateArticleTests : IClassFixture<UnitOfWorkFixture>
{
    readonly UnitOfWorkFixture _fixture;

    public CreateArticleTests(UnitOfWorkFixture fixture, ITestOutputHelper outputHelper)
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

        var cmd2 = new CreateArticleCommand(blogId, "A valid article", "A valid description", "A valid text");
        var result = await _fixture.Sender.Send(cmd2);




        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeGreaterThan(0);

    }
}
