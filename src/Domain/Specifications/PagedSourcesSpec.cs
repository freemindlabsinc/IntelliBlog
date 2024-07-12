using Blogging.Domain.Aggregates.Sources;

namespace Blogging.Domain.Specifications;

public class PagedSourcesSpec : Specification<Source>
{
    [Flags]
    public enum SourceIncludes
    {
        None = 0,
        Tags = 1,
        All = Tags
    }

    public PagedSourcesSpec(int? skip, int? take = 10, string? filter = default, SourceIncludes includes = SourceIncludes.None)
    {
        if (skip.HasValue)
            Query.Skip(skip.Value);

        if (take.HasValue)
            Query.Take(take.Value);

        if (includes.HasFlag(SourceIncludes.Tags))
            Query.Include(source => source.Tags);

        // TODO implement filter
    }
}
