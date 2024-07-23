using Blogging.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.DataLoaders;

public class SourceDataLoader(
    IBatchScheduler batchScheduler,
    IServiceProvider serviceProvider,
    DataLoaderOptions? options = null)

    : BatchDataLoader<int, Source>(batchScheduler, options)
{
    protected override async Task<IReadOnlyDictionary<int, Source>> LoadBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken)
    {
        await using var scope = serviceProvider.CreateAsyncScope();
        var sourceRepository = scope.ServiceProvider.GetRequiredService<IEntityRepository<Source>>();

        var sources = await sourceRepository.Source
            .Where(s => keys.Contains(s.Id))
            .ToDictionaryAsync(s => s.Id, cancellationToken);

        return sources;
    }
}
