using Application.UseCases.Articles.Create;

namespace API.Endpoints.Articles;

/// <summary>
/// Creates a new blog article.
/// </summary>
/// <param name="BlogId">The id of the blog to create the article in.</param>
/// <param name="Title">The title of the article.</param>
/// <param name="Description">The description of the article (optional).</param>
/// <param name="Text">The text of the article (optional).</param>
/// <param name="Tags">A list of tags for the article (optional).</param>
public readonly record struct CreateArticleRequest(
    int BlogId,
    string Title,
    string? Description,
    string? Text,
    string[]? Tags);

/// <summary>
/// The response for the create article endpoint.
/// </summary>
/// <param name="Id">The id of the created article.</param>
public readonly record struct CreateArticleResponse(int Id);

internal class Create(ISender _sender)
  : Endpoint<CreateArticleRequest, CreateArticleResponse>
{
    public override void Configure()
    {
        Post("/Articles");//CreateArticleRequest.Route);
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

        if (result.IsSuccess)
        {
            Response = new CreateArticleResponse(result.Value);
        }
        // TODO Handle errors
    }
}

internal class CreateArticleRequestValidator : Validator<CreateArticleRequest>
{
    public CreateArticleRequestValidator()
    {
        RuleFor(x => x.BlogId).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
    }
}
