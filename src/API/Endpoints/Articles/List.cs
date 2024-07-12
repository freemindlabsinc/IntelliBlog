using Application.UseCases.Articles.Queries.List;

namespace API.Endpoints.Articles;

/// <summary>
/// Returns a list of articles according to the specified parameters.
/// </summary>
public sealed class ListArticlesRequest() : ICommand<ListArticlesResponse>
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
}

/// <summary>
/// The response to the <see cref="ListArticlesQuery" />.
/// </summary>
/// <param name="Articles">The list of articles.</param>
public readonly record struct ListArticlesResponse(
     IEnumerable<ArticleResult> Articles);


internal class List(IMediator _mediator)
    : Endpoint<ListArticlesRequest, ListArticlesResponse>
{
    public override void Configure()
    {
        Get("/Articles");
        Description(x => x.WithName("ListArticles"));
        AllowAnonymous();
        Summary(s =>
        {
            // XML Docs are used by default but are overridden by these properties:
            //s.Summary = "List Articles.";
            //s.Description = "List Articles. A valid title is required.";            
            s.ExampleRequest = new ListArticlesRequest { Skip = 0, Take = 10 };
            s.ExampleRequest = new ListArticlesRequest { Skip = null, Take = null };
            s.ExampleRequest = new ListArticlesRequest { Skip = 10, Take = null };
        });
    }

    public override async Task HandleAsync(
        ListArticlesRequest request,
        CancellationToken cancellationToken)
    {
        var query = request.Adapt<ListArticlesQuery>();

        var result = await _mediator.Send(query, cancellationToken);

        if (result.IsSuccess)
        {
            var records = result.Value.Adapt<IEnumerable<ArticleResult>>();

            Response = new ListArticlesResponse(records);
            return;
        }
    }
}

internal class ListArticlesRequestValidator : Validator<ListArticlesQuery>
{
    public ListArticlesRequestValidator()
    {
        RuleFor(x => x.Skip).GreaterThanOrEqualTo(0).When(x => x.Skip.HasValue);
        RuleFor(x => x.Take).GreaterThanOrEqualTo(1).When(x => x.Take.HasValue);
        RuleFor(x => x.Filter).NotEmpty().When(x => x.Filter != null);
    }
}
