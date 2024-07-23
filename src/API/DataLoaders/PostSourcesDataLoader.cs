using Blogging.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.DataLoaders;

public class PostSourcesDataLoader(
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
        var sources = scope.ServiceProvider.GetRequiredService<IEntityRepository<Source>>().Source;
        var posts = scope.ServiceProvider.GetRequiredService<IEntityRepository<Post>>().Source;

        // select from sources src where src.id        
        var qry = from p in posts
                  from pa in p.Sources
                  join src in sources on pa.SourceId equals src.Id
                  where keys.Contains(pa.PostId)
                  select new { Source = src, PostId = pa.PostId };

        var res = await qry.ToListAsync(cancellationToken);

        //var lk = res.ToLookup(x => x.BlogId);
        var lk2 = res.ToLookup(x => x.PostId, x=> x.Source);
        return lk2;
        
    }
}
