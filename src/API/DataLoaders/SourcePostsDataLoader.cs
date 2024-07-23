using Blogging.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.DataLoaders;

public class SourcePostsDataLoader(
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
        var sources = scope.ServiceProvider.GetRequiredService<IEntityRepository<Source>>().Source;
        var posts = scope.ServiceProvider.GetRequiredService<IEntityRepository<Post>>().Source;

        // select from sources src where src.id        
        var qry = from p in posts
                  from ps in p.Sources
                  where keys.Contains(ps.SourceId)
                  select new { Post = p, SourceId = ps.SourceId };

        var res = await qry.ToListAsync(cancellationToken);

        //var lk = res.ToLookup(x => x.BlogId);
        var lk2 = res.ToLookup(x => x.SourceId, x => x.Post);
        return lk2;

    }
}
