namespace Blogging.Application.UseCases.Articles.Update;

public readonly record struct UpdateArticleTextCommand(
    ArticleId ArticleId,
    string Description,
    string Text
    ) : ICommand<Result>;
