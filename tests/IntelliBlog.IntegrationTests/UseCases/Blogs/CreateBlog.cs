using Ardalis.Result;
using FluentValidation;
using IntelliBlog.Application.Interfaces;
using IntelliBlog.Application.UseCases.Blogs.Create;
using IntelliBlog.Domain.Aggregates;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace IntelliBlog.IntegrationTests.UseCases.Blogs;

public class WithISenderFixture : FixtureBase
{
    public WithISenderFixture() : base() { }

    public void Dispose()
    {
    }

    public ISender GetSender() => GetServiceProvider().GetService<ISender>()!;
}

public class CreateBlogTests : IClassFixture<WithISenderFixture>
{
    readonly WithISenderFixture _fixture;

    public CreateBlogTests(WithISenderFixture fixture, ITestOutputHelper outputHelper)
        : base()
    {
        _fixture = fixture;
        _fixture.SetTestOutputHelper(outputHelper);
    }

    [Fact]
    public async Task Can_create_valid_blog()
    {
        var cmd = new CreateBlogCommand("A valid blog"); 
        var result = await _fixture.GetSender().Send(cmd);

        result.IsSuccess.Should().BeTrue();
        result.Value.Value.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task Cannot_create_invalid_blog()
    {
        var cmd = new CreateBlogCommand(); //

        Func<Task<Result<BlogId>>> func = () => _fixture.GetSender().Send(cmd);

        await func.Should().ThrowAsync<ValidationException>();
    }
}
