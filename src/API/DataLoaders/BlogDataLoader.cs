using Blogging.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.DataLoaders;

// https://github.com/ChilliCream/graphql-workshop/blob/master/code/session-8/GraphQL/Types/AttendeeType.cs
public class BlogDataLoader(
    IBatchScheduler batchScheduler,
    IServiceProvider serviceProvider,
    DataLoaderOptions? options = null)

    : BatchDataLoader<int, Blog>(batchScheduler, options)
{
    protected override async Task<IReadOnlyDictionary<int, Blog>> LoadBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken)
    {
        await using var scope = serviceProvider.CreateAsyncScope();
        var blogRepository = scope.ServiceProvider.GetRequiredService<IEntityRepository<Blog>>();

        var blogs = await blogRepository.Source
            .Where(b => keys.Contains(b.Id))
            .ToDictionaryAsync(b => b.Id, cancellationToken);

        return blogs;
    }
}
