using Blogging.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.DataLoaders;

public class PostDataLoader(
    IBatchScheduler batchScheduler,
    IServiceProvider serviceProvider,
    DataLoaderOptions? options = null)

    : BatchDataLoader<int, Post>(batchScheduler, options)
{
    protected override async Task<IReadOnlyDictionary<int, Post>> LoadBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken)
    {
        await using var scope = serviceProvider.CreateAsyncScope();
        var postRepository = scope.ServiceProvider.GetRequiredService<IEntityRepository<Post>>();

        var posts = await postRepository.Source
            .Where(p => keys.Contains(p.Id))
            .ToDictionaryAsync(p => p.Id, cancellationToken);

        return posts;
    }
}

