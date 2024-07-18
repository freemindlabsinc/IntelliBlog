using Application.Features.Blogs.Commands.Create;
using Application.Features.Blogs.Commands.Update;
using Ardalis.Result;
using MediatR;

namespace GraphQL.Blogs;

[MutationType]
public class BlogMutations
{
    public async Task<int> CreateBlog([Service] ISender _sender, string name, string? description)
    {
        var cmd = new CreateBlogCommand(name, description);
        var newBlogId = await _sender.Send(cmd, default);

        return newBlogId;
    }

    public async Task<Result> UpdateBlog([Service] ISender _sender, int id, string name, string? description)
    {
        var cmd = new UpdateBlogCommand(id, name, description, null);
        var updatedBlogId = await _sender.Send(cmd, default);

        return updatedBlogId;
    }
}
