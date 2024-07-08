namespace Blogging.Application.UseCases.Articles.Publish;
public readonly record struct PublishArticleCommand(ArticleId ArticleId) : ICommand<Result>;
