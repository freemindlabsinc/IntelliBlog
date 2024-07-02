namespace IntelliBlog.API.Endpoints.Articles;

public readonly record struct CreateArticleRequest(
    string Title,
    string Description,
    string Content,
    string[] Tags);
