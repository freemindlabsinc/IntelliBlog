using Blogging.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.DataLoaders;

//[UsePaging]
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
