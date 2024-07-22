using Blogging.Domain.Interfaces;

namespace API.Sources;

[QueryType]
public static class SourceQueries
{
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public static IQueryable<Source> GetSources(
        [Service] 
        IEntityRepository<Source> repository)
        
        => repository.Source;

    public static async Task<Source?> GetSourceByIdAsync(
        [Service] 
        IEntityRepository<Source> repository,

        [GraphQLType(typeof(IdType))] 
        int id)

        => await repository.GetByIdAsync(id);
}
