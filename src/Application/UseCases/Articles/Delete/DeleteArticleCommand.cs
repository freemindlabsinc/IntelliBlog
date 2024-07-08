namespace Blogging.Application.UseCases.Articles.Delete;

public readonly record struct DeleteArticleCommand(ArticleId Id) : ICommand<Result>;

