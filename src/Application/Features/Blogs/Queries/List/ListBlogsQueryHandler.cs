using Blogging.Domain.Aggregates.Blogs;

namespace Application.Features.Blogs.Queries.List;

internal class ListBlogsQueryHandler : IQueryHandler<ListBlogsQuery, Result<List<BlogDTO>>>
{
    private readonly IRepository<Blog> _repository;

    public ListBlogsQueryHandler(IRepository<Blog> repository)
    {
        _repository = repository;
    }

    public async Task<Result<List<BlogDTO>>> Handle(ListBlogsQuery query, CancellationToken cancellationToken)
    {
        var spec = new PagedBlogsSpec(query.Skip, query.Take, query.Filter);
        var blogs = await _repository.ListAsync(spec, cancellationToken);

        var blogDTOs = blogs.Adapt<List<BlogDTO>>();

        return Result.Success(blogDTOs.ToList());
    }
}
