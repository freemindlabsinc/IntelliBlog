using Blogging.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Types;

// https://github.com/ChilliCream/graphql-workshop/blob/master/code/session-8/GraphQL/Types/AttendeeType.cs

[Node]
[ExtendObjectType<Blog>]
public static class BlogNode
{
    //[UsePaging]
    //[UseFiltering]
    //[UseSorting]
    //public static async Task<IEnumerable<Post>> GetPostsXXX(
    //        [ID(nameof(Blog))] int id,
    //
    //        //[Service]
    //        IPostsByBlogIdDataLoader postsLoader)
    //{
    //    return await postsLoader.LoadAsync(id);
    //}

    public static async Task<IEnumerable<Post>> GetPostsByBlogIdAsync(
            [ID(nameof(Blog))] int id,
            [Service]IEntityRepository<Post> postRepository,
            IPostsByBlogIdsDataLoader postsByBlogId,
            CancellationToken cancellationToken)
    {
        int[] postIds = await postRepository.Source
            .Where(p => p.Id == id)
            .Select(p => p.Id)
            .ToArrayAsync();

        var x = await postsByBlogId.LoadAsync(postIds, cancellationToken);
        return x;
    }

    [DataLoader]
    internal static async Task<Blog> GetBlogByIdAsync(
        [ID(nameof(Blog))] int id,
        IBlogByIdDataLoader blogById,
        CancellationToken cancellationToken)

        => await blogById.LoadAsync(id, cancellationToken);

    [DataLoader]
    internal static async Task<IEnumerable<Blog>> GetBlogsById(
        [ID(nameof(Blog))] int[] ids,
        IBlogByIdDataLoader blogById,
        CancellationToken cancellationToken)
    
        => await blogById.LoadAsync(ids, cancellationToken);

}
