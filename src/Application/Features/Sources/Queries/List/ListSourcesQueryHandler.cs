using Blogging.Domain.Aggregates.Sources;

namespace Application.Features.Sources.Queries.List;

public readonly partial record struct ListSourcesQuery
{
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
}
