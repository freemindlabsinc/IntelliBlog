namespace Blogging.Application.UseCases.Articles.Unpublish;

public readonly record struct UnpublishArticleCommand(ArticleId ArticleId) : ICommand<Result>;
