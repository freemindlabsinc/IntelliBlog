using Application.Features.Blogs.Queries.List;

namespace API.Endpoints.Blogs.List;


internal class ListBlogsEndpoint(IMediator _mediator)
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
