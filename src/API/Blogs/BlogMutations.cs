using Ardalis.Result;
using Blogging.Application.Blogs.Commands;
using MediatR;

namespace API.Blogs;

[MutationType]
public static class BlogMutations
{
    public static Task<Ardalis.Result.Result<int>> CreateBlog([Service] ISender _sender, string name, string? description = default, string? image = default, string? notes = default)
    {
        var cmd = new CreateBlogCommand(name, description, image, notes);
        return _sender.Send(cmd, default);
    }

    public static Task<Result> UpdateBlog([Service] ISender _sender, int id, string name, string? description = default, string? notes = default)
    {
        var cmd = new UpdateBlogCommand(id, name, description, notes);
        return _sender.Send(cmd, default);
    }
}
