using Ardalis.Specification;
using FreeMindLabs.IntelliBlog.Core.Domain.Contributor;

namespace FreeMindLabs.IntelliBlog.Core.Domain.Contributor.Specifications;

public class ContributorByIdSpec : Specification<Contributor>
{
    public ContributorByIdSpec(int contributorId)
    {
        Query
            .Where(contributor => contributor.Id == contributorId);
    }
}
