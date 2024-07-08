using Blogging.Application.UseCases.Articles.Create;
using Blogging.Domain.Aggregates;
using FastEndpoints;

namespace Blogging.API.Endpoints.Articles;

public class Create(ISender _sender)
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
            s.ExampleRequest = new CreateArticleRequest 
            {
                BlogId = 1,
                Title = "Article Title",
                Description = "An optional description for the article",
                Text = "### Article Content",
                Tags = new [] { "Tag1", "Tag2" }
            };
        });
    }

    public override async Task HandleAsync(
      CreateArticleRequest request,
      CancellationToken cancellationToken)
    {
        var command = new CreateArticleCommand(
            BlogId: request.BlogId,
            Title: request.Title,
            Description: request.Description,
            Text: request.Text,
            Tags: request.Tags);

        Result<ArticleId> result = await _sender.Send(command);

        if (result.IsSuccess)
        {
            Response = new CreateArticleResponse(result.Value.Value);
        }
        // TODO Handle errors
    }
}
