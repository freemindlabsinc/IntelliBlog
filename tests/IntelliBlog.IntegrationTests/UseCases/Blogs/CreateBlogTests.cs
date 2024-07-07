using Ardalis.Result;
using FluentValidation;
using IntelliBlog.Application.UseCases.Blogs.Create;
using IntelliBlog.Domain.Aggregates;
using Xunit.Abstractions;

namespace IntelliBlog.IntegrationTests.UseCases.Blogs;

public class CreateBlogTests : IClassFixture<UnitOfWorkFixture>
{
    readonly UnitOfWorkFixture _fixture;

    public CreateBlogTests(UnitOfWorkFixture fixture, ITestOutputHelper outputHelper)
        : base()
    {
        _fixture = fixture;
        _fixture.SetTestOutputHelper(outputHelper);
    }

    [Fact]
    public async Task Can_create_valid_blog()
    {
        var cmd = new CreateBlogCommand("A valid blog"); 
        var result = await _fixture.Sender.Send(cmd);

        result.IsSuccess.Should().BeTrue();
        result.Value.Value.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task Cannot_create_invalid_blog()
    {
        var cmd = new CreateBlogCommand(); //
        Func<Task<Result<BlogId>>> func = () => _fixture.Sender.Send(cmd);

        await func.Should().ThrowAsync<ValidationException>();
    }    
}
