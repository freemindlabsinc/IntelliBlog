namespace Application.UseCases.Articles.List;

public class ListArticlesQueryValidator : AbstractValidator<ListArticlesQuery>
{
    public ListArticlesQueryValidator()
    {
        RuleFor(x => x.Skip).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Take).GreaterThanOrEqualTo(1);
    }
}
