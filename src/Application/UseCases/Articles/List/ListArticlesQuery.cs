namespace Application.UseCases.Articles.List;

public readonly record struct ListArticlesQuery(
    int? Skip = 0,
    int? Take = 10) 
    : IQuery<Result<IEnumerable<ArticleDTO>>>;

public class ListArticlesQueryValidator : AbstractValidator<ListArticlesQuery>
{
    public ListArticlesQueryValidator()
    {
        RuleFor(x => x.Skip).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Take).GreaterThanOrEqualTo(1);
    }
}
