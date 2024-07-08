namespace Blogging.API.Endpoints.Articles;

public readonly record struct CreateArticleRequest(
    int BlogId,
    string Title,
    string Description,
    string Content,
    string[] Tags);
