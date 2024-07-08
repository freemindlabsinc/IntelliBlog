using FluentValidation;

namespace Blogging.API.Endpoints.Articles;

public class ListArticlesValidator : AbstractValidator<ListArticlesRequest>
{
    public ListArticlesValidator()
    {
        RuleFor(x => x.Skip).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Take).GreaterThanOrEqualTo(1);
    }
}
