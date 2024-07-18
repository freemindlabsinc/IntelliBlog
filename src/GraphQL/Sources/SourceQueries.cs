using Blogging.Domain.Aggregates.Sources;
using Blogging.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Sources;

[QueryType]
public class SourceQueries
{
    [UsePaging]
    [HotChocolate.Data.UseFiltering]
    [HotChocolate.Data.UseSorting]
    public IQueryable<Source> GetSources(
        [Service(ServiceKind.Synchronized)] AppDbContext db)
        => db.Sources;

    public Task<Source?> GetSourceById(
        [Service(ServiceKind.Synchronized)] AppDbContext db,
        [GraphQLType(typeof(IdType))] int id)
        => db.Sources.FirstOrDefaultAsync(x => x.Id == id);
}
