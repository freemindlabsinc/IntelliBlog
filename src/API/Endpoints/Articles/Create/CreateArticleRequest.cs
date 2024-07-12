namespace API.Endpoints.Articles.Create;

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
    string[]? Tags) : IRequest<CreateArticleResponse>
{
    internal class CreateArticleRequestValidator : Validator<CreateArticleRequest>
    {
        public CreateArticleRequestValidator()
        {
            RuleFor(x => x.BlogId).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
