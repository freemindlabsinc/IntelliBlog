using Blogging.Domain;
using GraphQL.Types;
using Infrastructure2.Data;

namespace GraphQL.Articles;

[QueryType]
public static class PostsQueries
{
    [UsePaging]
    [HotChocolate.Data.UseFiltering]
    [HotChocolate.Data.UseSorting]
    public static IQueryable<Post> GetPosts(
        [Service(ServiceKind.Synchronized)] AppDbContext db)
    {

        return db.Posts;
    }
    
    public static async Task<Post?> GetPostById(
        int id,
        IArticleByIdDataLoader articleById,
        CancellationToken cancellationToken)
        => await articleById.LoadAsync(id, cancellationToken);
}
