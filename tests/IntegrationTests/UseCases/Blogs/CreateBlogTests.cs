﻿using Ardalis.Result;
using Blogging.Application.Blogs.Commands;
using Blogging.Domain.Base;
using FluentValidation;
using Xunit.Abstractions;

namespace Blogging.IntegrationTests.UseCases.Blogs;

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
        var cmd = new CreateBlogCommand("A valid blog", Description: "");
        var result = await _fixture.Sender.Send(cmd);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task Cannot_create_invalid_blog()
    {
        var cmd = new CreateBlogCommand(string.Empty);
        Func<Task<Result<int>>> func = () => _fixture.Sender.Send(cmd);

        await func.Should().ThrowAsync<ValidationException>();
    }

    
}
