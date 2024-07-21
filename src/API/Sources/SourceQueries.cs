using Blogging.Domain.Interfaces;

namespace GraphQL.Sources;

[QueryType]
public static class SourceQueries
{
    [UsePaging]
    [HotChocolate.Data.UseFiltering]
    [HotChocolate.Data.UseSorting]
    public static IQueryable<Source> GetSources(
        [Service(ServiceKind.Synchronized)] IEntityRepository<Source> repository)
        => repository.Source;

    public static async Task<Ardalis.Result.Result<Source>> GetSourceByIdAsync(
        [Service(ServiceKind.Synchronized)] IEntityRepository<Source> repository,
        [GraphQLType(typeof(IdType))] int id)
        => await repository.FindAsync(id);
}
