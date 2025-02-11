﻿using Ardalis.Result;
using Blogging.Application.Blogs.Commands;
using Xunit.Abstractions;

namespace Blogging.IntegrationTests.UseCases.Blogs;

public class UpdateBlogTests : IClassFixture<UnitOfWorkFixture>
{
    readonly UnitOfWorkFixture _fixture;
    
    public UpdateBlogTests(UnitOfWorkFixture fixture, ITestOutputHelper outputHelper)
        : base()
    {
        _fixture = fixture;
        _fixture.SetTestOutputHelper(outputHelper);
    }


    [Fact]
    public async Task Can_update_existing_blog()
    {
        Result<int> blogId = await _fixture.Sender.Send(
            new CreateBlogCommand("A valid blog"));
        blogId.IsSuccess.Should().BeTrue();
        blogId.Value.Should().BeGreaterThan(0);

        //
        var result = await _fixture.Sender.Send(
            new UpdateBlogCommand(blogId.Value, "An updated blog", "DescriptionA", "NotesA"));
        result.IsSuccess.Should().BeTrue();

        //
        var updatedBlog = await _fixture.BlogRepository.GetByIdAsync(blogId.Value);

        updatedBlog.Should().NotBeNull();
        updatedBlog.Name.Should().Be("An updated blog");
        updatedBlog.Description.Should().Be("DescriptionA");
        updatedBlog.Notes.Should().Be("NotesA");
    }
}
