using Ardalis.Specification;
using IntelliBlog.Core.Domain.Contributor;

namespace IntelliBlog.Core.Domain.Contributor.Specifications;

public class ContributorByIdSpec : Specification<Contributor>
{
    public ContributorByIdSpec(int contributorId)
    {
        Query
            .Where(contributor => contributor.Id == contributorId);
    }
}
