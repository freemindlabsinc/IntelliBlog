using Application.Features.Sources.Queries.List;

namespace API.Endpoints.Sources.List;

internal class ListSourcesEndpoint(IMediator _mediator) : Endpoint<ListSourcesRequest, ListSourcesResponse>
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
            var records = result.Value.Adapt<IEnumerable<SourceResult>>();

            Response = new ListSourcesResponse(records);
            return;
        }
    }
}
