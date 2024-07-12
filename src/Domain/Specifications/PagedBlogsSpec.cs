using Blogging.Domain.Aggregates.Blogs;

namespace Blogging.Domain.Specifications;

public class PagedBlogsSpec : Specification<Blog>
{
    public PagedBlogsSpec(int? skip, int? take = 10, string? filter = default)
    {
        if (skip.HasValue)
            Query.Skip(skip.Value);

        if (take.HasValue)
            Query.Take(take.Value);

        // TODO implement filter
    }
}
