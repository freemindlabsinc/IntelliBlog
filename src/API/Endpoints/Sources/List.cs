using API.Endpoints.Sources;
using Application.UseCases.Sources.Queries.List;

namespace API.Endpoints.Blogs;

/// <summary>
/// Returns a list of articles according to the specified parameters.
/// </summary>
public sealed class ListSourcesRequest : IQuery<ListSourcesResponse>
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
/// The response to the <see cref="ListBlogsRequest" />.
/// </summary>
/// <param name="Sources">The list of sources.</param>
public readonly record struct ListSourcesResponse(
     IEnumerable<SourceResult> Sources);


internal class List_(IMediator _mediator)
    : Endpoint<ListSourcesRequest, ListSourcesResponse>
{
    public override void Configure()
    {
        Get("/Sources");
        Description(x => x.WithName("ListSources"));
        AllowAnonymous();
        Summary(s =>
        {
            // XML Docs are used by default but are overridden by these properties:
            //s.Summary = "List Articles.";
            //s.Description = "List Articles. A valid title is required.";            
            s.ExampleRequest = new ListSourcesRequest { Skip = 0, Take = 10 };
            s.ExampleRequest = new ListSourcesRequest { Skip = null, Take = null };
            s.ExampleRequest = new ListSourcesRequest { Skip = 10, Take = null };
        });
    }

    public override async Task HandleAsync(
        ListSourcesRequest request,
        CancellationToken cancellationToken)
    {
        var query = request.Adapt<ListSourcesQuery>();

        var result = await _mediator.Send(query, cancellationToken);

        if (result.IsSuccess)
        {
            IEnumerable<SourceResult> records = result.Value.Adapt<IEnumerable<SourceResult>>();
                
            Response = new ListSourcesResponse(records);
            return;
        }
    }
}

internal class ListSourcesRequestValidator : Validator<ListSourcesRequest>
{
    public ListSourcesRequestValidator()
    {
        RuleFor(x => x.Skip).GreaterThanOrEqualTo(0).When(x => x.Skip.HasValue);
        RuleFor(x => x.Take).GreaterThanOrEqualTo(1).When(x => x.Take.HasValue);
        RuleFor(x => x.Filter).NotEmpty().When(x => x.Filter != null);
    }
}
