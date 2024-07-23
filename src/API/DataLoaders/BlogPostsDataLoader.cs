using Blogging.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.DataLoaders;

[UsePaging]
public class BlogPostsDataLoader(
    IBatchScheduler batchScheduler,
    IServiceProvider serviceProvider,
    DataLoaderOptions? options = null)

    : GroupedDataLoader<int, Post>(batchScheduler, options)
{
    protected override async Task<ILookup<int, Post>> LoadGroupedBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken)
    {
        await using var scope = serviceProvider.CreateAsyncScope();
        var postRepository = scope.ServiceProvider.GetRequiredService<IEntityRepository<Post>>();

        var posts = await postRepository.Source
            .Where(p => keys.Contains(p.BlogId))
            .ToListAsync(cancellationToken);

        return posts.ToLookup(x => x.BlogId);
    }
}
