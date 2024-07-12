using Application.Features.Articles.Queries.List;

namespace API.Endpoints.Articles.List;

/// <summary>
/// Returns a list of articles according to the specified parameters.
/// </summary>
public sealed class ListArticlesRequest() : IRequest<ListArticlesResponse>
{
    /// <summary>
    /// The number of articles to skip.
    /// </summary>
    [QueryParam]
    public int? Skip { get; init; }

    /// <summary>
    /// The number of articles to return.
    /// </summary>    
    [QueryParam]
    public int? Take { get; init; }

    /// <summary>
    /// An optional filter to apply to the articles.
    /// </summary>
    [QueryParam]
    public string? Filter { get; init; }

    internal class ListArticlesRequestValidator : Validator<ListArticlesQuery>
    {
        public ListArticlesRequestValidator()
        {
            RuleFor(x => x.Skip).GreaterThanOrEqualTo(0).When(x => x.Skip.HasValue);
            RuleFor(x => x.Take).GreaterThanOrEqualTo(1).When(x => x.Take.HasValue);
            RuleFor(x => x.Filter).NotEmpty().When(x => x.Filter != null);
        }
    }

}
