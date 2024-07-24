using API.DataLoaders;

namespace API.Types;

public class SourceType : ObjectType<Source>
{
    protected override void Configure(IObjectTypeDescriptor<Source> descriptor)
    {
        descriptor.Field(t => t.BlogId).Ignore();        
    }    
}

[ExtendObjectType<Source>]
public static class SourceTypeExtensions
{
    [UseSingleOrDefault] // Seems inconsequential
    [UseProjection] // Seems inconsequential
    public static async Task<Blog> GetBlog(
        [Parent] Source source,
        BlogDataLoader blogDataLoader,
        CancellationToken cancellationToken)
    {
        return await blogDataLoader.LoadAsync(source.BlogId, cancellationToken);
    }

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public static async Task<IEnumerable<Post>> GetPosts(
        [Parent] Source source,
        SourcePostsDataLoader sourcePostsDataLoader,
        CancellationToken cancellationToken)
    {
        return await sourcePostsDataLoader.LoadAsync(source.Id, cancellationToken);
    }

    
}
