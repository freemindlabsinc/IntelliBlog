using Blogging.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.DataLoaders;

public class BlogSourcesDataLoader(
    IBatchScheduler batchScheduler,
    IServiceProvider serviceProvider,
    DataLoaderOptions? options = null)

    : GroupedDataLoader<int, Source>(batchScheduler, options)
{
    protected override async Task<ILookup<int, Source>> LoadGroupedBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken)
    {
        await using var scope = serviceProvider.CreateAsyncScope();
        var sourceRepository = scope.ServiceProvider.GetRequiredService<IEntityRepository<Source>>();

        var sources = await sourceRepository.Source
            .Where(p => keys.Contains(p.BlogId))
            .ToListAsync(cancellationToken);

        return sources.ToLookup(x => x.BlogId);
    }
}
