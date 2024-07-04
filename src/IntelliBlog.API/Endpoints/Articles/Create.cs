using FastEndpoints;
using IntelliBlog.API.Application.UseCases.Articles.Create;

namespace IntelliBlog.API.Endpoints.Articles;

public class Create(IMediator _mediator)
  : Endpoint<CreateArticleRequest, CreateArticleResponse>
{
    public override void Configure()
    {
        Post("/Articles");//CreateArticleRequest.Route);
        AllowAnonymous();
        Summary(s =>
        {
            // XML Docs are used by default but are overridden by these properties:
            //s.Summary = "Create a new Article.";
            //s.Description = "Create a new Article. A valid title is required.";
            s.ExampleRequest = new CreateArticleRequest { Title = "Article Title" };
        });
    }

    public override async Task HandleAsync(
      CreateArticleRequest request,
      CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CreateArticleCommand(
            request.BlogId,
            request.Title, request.Description, request.Content, request.Tags), cancellationToken);

        if (result.IsSuccess)
        {
            Response = new CreateArticleResponse(result.Value);
            return;
        }
    }
}
