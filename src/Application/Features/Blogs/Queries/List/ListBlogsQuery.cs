namespace Application.Features.Blogs.Queries.List;

public readonly record struct ListBlogsQuery(
    int? Skip = 0,
    int? Take = 10,
    string? Filter = default) 
    : IQuery<Result<List<BlogDTO>>>
{
    internal class ListBlogCommandValidator : AbstractValidator<ListBlogsQuery>
    {
        public ListBlogCommandValidator()
        {
            RuleFor(x => x.Skip).GreaterThanOrEqualTo(0).When(x => x.Skip.HasValue);
            RuleFor(x => x.Take).GreaterThanOrEqualTo(1).When(x => x.Take.HasValue);
        }
    }
}
