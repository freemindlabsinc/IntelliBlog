using FluentValidation;

namespace API.Endpoints.Articles.List;

public class ListArticlesValidator : AbstractValidator<ListArticlesRequest>
{
    public ListArticlesValidator()
    {
        When(x => x.Skip.HasValue, () =>
        {
            RuleFor(x => x.Skip).GreaterThanOrEqualTo(0);
        });
        
        When(x => x.Take.HasValue, () =>
        {
            RuleFor(x => x.Take).GreaterThanOrEqualTo(1);
        });        
    }
}
