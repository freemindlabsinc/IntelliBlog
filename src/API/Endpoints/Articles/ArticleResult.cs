
namespace API.Endpoints.Articles;

public readonly record struct ArticleResult(
    int Id,
    string Title,
    string? Description,
    DateTime CreatedOn,
    DateTime? LastModifiedOn);
