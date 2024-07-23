using API.DataLoaders;

namespace API.Types;

public class PostType : ObjectType<Post>
{
    protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
    {
        descriptor.Field(t => t.BlogId).Ignore();
    }
}

[ExtendObjectType<Post>]
public static class PostTypeExtensions
{
    [UseSingleOrDefault] // Seems inconsequential
    [UseProjection] // Seems inconsequential
    public static async Task<Blog> GetBlog(
        [Parent] Post post,
        BlogDataLoader blogDataLoader,
        CancellationToken cancellationToken)
    {
        return await blogDataLoader.LoadAsync(post.BlogId, cancellationToken);
    }

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public static async Task<IEnumerable<Source>> GetSources(
        [Parent] Post post,
        PostSourcesDataLoader postSources,
        CancellationToken cancellationToken)

        => await postSources.LoadAsync(post.Id, cancellationToken);
}
