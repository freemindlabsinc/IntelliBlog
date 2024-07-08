namespace Blogging.Application.UseCases.Articles.Create;
public readonly record struct CreateArticleCommand(
    BlogId BlogId,
    string Title,
    string? Description = default) : ICommand<Result<ArticleId>>;
