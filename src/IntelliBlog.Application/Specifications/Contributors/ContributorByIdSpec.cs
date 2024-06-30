using IntelliBlog.Domain.Contributor;

namespace IntelliBlog.Application.Specifications.Contributors;

public class ContributorByIdSpec : Specification<Contributor>
{
    public ContributorByIdSpec(int contributorId)
    {
        Query
            .Where(contributor => contributor.Id == contributorId);
    }
}
