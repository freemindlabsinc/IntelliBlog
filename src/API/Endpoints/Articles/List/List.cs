using Application.UseCases.Articles.List;
using FastEndpoints;

namespace API.Endpoints.Articles.List;

public class List(IMediator _mediator)
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
        var query = new ListArticlesQuery(request.Skip, request.Take);

        var result = await _mediator.Send(query, cancellationToken);

        if (result.IsSuccess)
        {
            var records = result.Value
                .Select(x => ArticleResult.FromArticleDTO(x));                    

            Response = new ListArticlesResponse(records);
            return;
        }
    }
}
