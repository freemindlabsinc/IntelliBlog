namespace API.Endpoints.Articles.List;

public readonly record struct ArticleResult(
    int Id,
    string Title,
    string? Description,
    DateTime CreatedOn,
    DateTime? LastModifiedOn);
