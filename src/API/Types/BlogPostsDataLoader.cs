using Blogging.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Types;

public class BlogPostsDataLoader(
    IBatchScheduler batchScheduler,
    IEntityRepository<Post> postRepository,
    DataLoaderOptions? options = null)

    : GroupedDataLoader<int, Post>(batchScheduler, options)
{
    protected override async Task<ILookup<int, Post>> LoadGroupedBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken)
    {
        var posts = await postRepository.Source
            .Where(p => keys.Contains(p.BlogId))
            .ToListAsync(cancellationToken);

        return posts.ToLookup(x => x.BlogId);
    }
}
