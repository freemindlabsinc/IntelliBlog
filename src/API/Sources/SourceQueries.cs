using Blogging.Domain.Interfaces;

namespace API.Sources;

[QueryType]
public static class SourceQueries
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public static IQueryable<Source> GetSources(
        [Service(ServiceKind.Synchronized)]
        IEntityRepository<Source> repository)
        
        => repository.Source;

    public static async Task<Source?> GetSourceByIdAsync(
        [Service] 
        IEntityRepository<Source> repository,

        [GraphQLType<IdType>] 
        int id)

        => await repository.GetByIdAsync(id);
}
