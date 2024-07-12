using Blogging.Domain.Aggregates.Blogs;

namespace Application.UseCases.Blogs.Queries.List;

public readonly record struct ListBlogsQuery(
    int? Skip = 0,
    int? Take = 10,
    string? Filter = default) 
    : IQuery<Result<List<BlogDTO>>>;

internal class ListBlogsCommandHandler : IQueryHandler<ListBlogsQuery, Result<List<BlogDTO>>>
{
    private readonly IRepository<Blog> _repository;

    public ListBlogsCommandHandler(IRepository<Blog> repository)
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

internal class ListBlogCommandValidator : AbstractValidator<ListBlogsQuery>
{
    public ListBlogCommandValidator()
    {
        RuleFor(x => x.Skip).GreaterThanOrEqualTo(0).When(x => x.Skip.HasValue);
        RuleFor(x => x.Take).GreaterThanOrEqualTo(1).When(x => x.Take.HasValue);
    }
}
