using Blogging.Domain.Aggregates.Sources;

namespace Application.Features.Sources.Queries.List;

public readonly record struct ListSourcesQuery(
    int? Skip = 0,
    int? Take = 10,
    string? filter = default) : IQuery<Result<IEnumerable<SourceDTO>>>;

internal class ListSourcesQueryHandler(IRepository<Source> _repository) 
    : IQueryHandler<ListSourcesQuery, Result<IEnumerable<SourceDTO>>>
{    
    public async Task<Result<IEnumerable<SourceDTO>>> Handle(ListSourcesQuery query, CancellationToken cancellationToken)
    {
        var spec = new PagedSourcesSpec(query.Skip, query.Take);

        var sources = await _repository.ListAsync(spec, cancellationToken);

        var sourceDTOs = sources.Select(s => s.Adapt<SourceDTO>());

        return Result<IEnumerable<SourceDTO>>.Success(sourceDTOs);
    }
}
