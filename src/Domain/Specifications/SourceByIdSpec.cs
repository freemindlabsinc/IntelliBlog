using Blogging.Domain.Aggregates;
using Blogging.Domain.Aggregates.Sources;

namespace Blogging.Domain.Specifications;

public class SourceByIdSpec : Specification<Source>, ISingleResultSpecification<Source>
{
    public SourceByIdSpec(SourceId sourceId)
    {
        Query
            .Where(source => source.Id == sourceId);
    }
}
