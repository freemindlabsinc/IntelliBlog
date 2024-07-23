using Blogging.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Types;

// https://github.com/ChilliCream/graphql-workshop/blob/master/code/session-8/GraphQL/Types/AttendeeType.cs
public class BlogDataLoader(
    IBatchScheduler batchScheduler, 
    IEntityRepository<Blog> blogRepository, 
    DataLoaderOptions? options = null) 
    
    : BatchDataLoader<int, Blog>(batchScheduler, options)
{
    protected override async Task<IReadOnlyDictionary<int, Blog>> LoadBatchAsync(
        IReadOnlyList<int> keys, 
        CancellationToken cancellationToken)
    {
        var blogs = await blogRepository.Source
            .Where(b => keys.Contains(b.Id))
            .ToDictionaryAsync(b => b.Id, cancellationToken);

        return blogs;
    }
}
