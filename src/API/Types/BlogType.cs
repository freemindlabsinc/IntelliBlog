using API.DataLoaders;

namespace API.Types;

public class BlogType : ObjectType<Blog>
{ }

[ExtendObjectType<Blog>]
public static class BlogTypeExtensions 
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public static async Task<IEnumerable<Post>> GetPosts(
        [Parent] Blog blog,
        [Service] BlogPostsDataLoader dataLoader,
        CancellationToken cancellationToken)
    {
        return await dataLoader.LoadAsync(blog.Id, cancellationToken);
    }


    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public static async Task<IEnumerable<Source>> GetSources(
        [Parent] Blog blog,
        [Service] BlogSourcesDataLoader dataLoader,
        CancellationToken cancellationToken)
    {
        return await dataLoader.LoadAsync(blog.Id, cancellationToken);
    }
}
