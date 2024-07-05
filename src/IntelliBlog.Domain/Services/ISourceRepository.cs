using IntelliBlog.Domain.Aggregates.Sources;

namespace IntelliBlog.Domain.Services;

public interface  ISourceRepository
{
    public Task<Source> GetByIdAsync(SourceId sourceId, CancellationToken cancellationToken = default);
    public Task<Source> AddAsync(Source source, CancellationToken cancellationToken = default);
    public Task<Source> DeleteAsync(Source source, CancellationToken cancellationToken = default);
}
