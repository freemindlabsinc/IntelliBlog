using Application.UseCases.Blogs.Queries.List;

namespace API.Endpoints.Blogs;

/// <summary>
/// Returns a list of articles according to the specified parameters.
/// </summary>
public sealed class ListBlogsRequest() : ICommand<ListBlogsResponse>
{
    /// <summary>
    /// The number of items to skip.
    /// </summary>
    [QueryParam]
    public int? Skip { get; init; }

    /// <summary>
    /// The number of items to return.
    /// </summary>    
    [QueryParam]
    public int? Take { get; init; }

    /// <summary>
    /// An optional filter to apply to the items.
    /// </summary>
    [QueryParam]
    public string? Filter { get; init; }
}

/// <summary>
/// The response to the <see cref="ListBlogsQuery" />.
/// </summary>
/// <param name="Articles">The list of blog.</param>
public readonly record struct ListBlogsResponse(
     IEnumerable<BlogResult> Articles);


internal class List(IMediator _mediator)
    : Endpoint<ListBlogsRequest, ListBlogsResponse>
{
    public override void Configure()
    {
        Get("/Blogs");
        Description(x => x.WithName("ListBlogs"));
        AllowAnonymous();
        Summary(s =>
        {
            // XML Docs are used by default but are overridden by these properties:
            //s.Summary = "List Articles.";
            //s.Description = "List Articles. A valid title is required.";            
            s.ExampleRequest = new ListBlogsRequest { Skip = 0, Take = 10 };
            s.ExampleRequest = new ListBlogsRequest { Skip = null, Take = null };
            s.ExampleRequest = new ListBlogsRequest { Skip = 10, Take = null };
        });
    }

    public override async Task HandleAsync(
        ListBlogsRequest request,
        CancellationToken cancellationToken)
    {
        var query = request.Adapt<ListBlogsQuery>();

        var result = await _mediator.Send(query, cancellationToken);

        if (result.IsSuccess)
        {
            var records = result.Value.Adapt<IEnumerable<BlogResult>>();
                
            Response = new ListBlogsResponse(records);
            return;
        }
    }
}

internal class ListArticlesRequestValidator : Validator<ListBlogsRequest>
{
    public ListArticlesRequestValidator()
    {
        RuleFor(x => x.Skip).GreaterThanOrEqualTo(0).When(x => x.Skip.HasValue);
        RuleFor(x => x.Take).GreaterThanOrEqualTo(1).When(x => x.Take.HasValue);
        RuleFor(x => x.Filter).NotEmpty().When(x => x.Filter != null);
    }
}
