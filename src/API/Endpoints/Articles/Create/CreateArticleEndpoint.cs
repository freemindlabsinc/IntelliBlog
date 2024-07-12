using Application.Features.Articles.Commands.Create;

namespace API.Endpoints.Articles.Create;

internal class CreateArticleEndpoint(ISender _sender)
  : Endpoint<CreateArticleRequest, CreateArticleResponse>
{
    public override void Configure()
    {
        Post("/Articles");
        Description(x => x.WithName("CreateArticle"));
        AllowAnonymous();
        Summary(s =>
        {
            // XML Docs are used by default but are overridden by these properties:
            //s.Summary = "Create a new Article.";
            //s.Description = "Create a new Article. A valid title is required.";
            s.ExampleRequest = new CreateArticleRequest
            {
                BlogId = 1,
                Title = "Article Title",
                Description = "An optional description for the article",
                Text = "### Article Content",
                Tags = ["Tag1", "Tag2"]
            };
        });
    }

    public override async Task HandleAsync(
      CreateArticleRequest request,
      CancellationToken cancellationToken)
    {
        var command = request.Adapt<CreateArticleCommand>();

        var result = await _sender.Send(command, cancellationToken);

        //await SendAsync()

        if (result.IsSuccess)
        {
            Response = new CreateArticleResponse(result.Value);
            return;
        }
        // TODO Handle errors
    }
}
