using Blogging.Domain.Aggregates;
using Blogging.Domain.Aggregates.Blogs;

namespace Blogging.Domain.Specifications;

public class BlogByIdSpec : Specification<Blog>, ISingleResultSpecification<Blog>
{
    public BlogByIdSpec(int blogId)
    {
        Query
            .Where(blog => blog.Id == blogId);
    }
}
