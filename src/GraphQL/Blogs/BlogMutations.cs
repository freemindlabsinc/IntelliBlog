using Ardalis.Result;
using MediatR;

namespace GraphQL.Blogs;

[MutationType]
public class BlogMutations
{
    public Task<int> CreateBlog([Service] ISender _sender, string name, string? description)
    {
        //var cmd = new CreateBlogCommand(name, description);
        //var newBlogId = await _sender.Send(cmd, default);
        //
        //return newBlogId;
        return Task.FromResult(0);
    }

    public Task<Result> UpdateBlog([Service] ISender _sender, int id, string name, string? description)
    {
        //var cmd = new UpdateBlogCommand(id, name, description, null);
        //var updatedBlogId = await _sender.Send(cmd, default);
        //
        //return updatedBlogId;
        return Task.FromResult(Result.Success());
    }
}
